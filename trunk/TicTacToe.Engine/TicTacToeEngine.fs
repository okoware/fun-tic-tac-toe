namespace TicTacToe.Engine
open System
open TicTacToe.Engine
open TicTacToe.Engine.Model

/// <summary>A tic-tac-toe game engine</summary>
module TicTacToeEngine =
    /// <summary>An empty board</summary>
    let EmptyBoard = [E;E;E; E;E;E; E;E;E]

    /// Get the opponent piece for the given piece
    let Opponent piece = match piece with | X -> O | O -> X | _ -> failwith "Empty item has no opponent"

    /// <summary>Get the <see cref="System.String" /> representation of the board</summary>
    /// <param name="board">The board to display the <see cref="System.String" /> representation for</param>
    let rec ToString board =
        let ToPieceString = function | p when p = X -> 'X' | p when p = O -> 'O' | _ -> ' '
        let ToRowString col1 col2 col3 = sprintf "|%c|%c|%c|\n-------" (ToPieceString col1) (ToPieceString col2) (ToPieceString col3)
        match board with
        | a::b::c::rest -> sprintf "%s%s%s" (ToRowString a b c) System.Environment.NewLine (ToString rest)
        | [] -> System.String.Empty
        | _ -> failwith "Invalid board dimension"

    /// <summary>Apply a move to the board</summary>
    /// <param name="piece">The piece to move</param>
    /// <param name="position">The position to move the piece to</param>
    /// <param name="board">The board to apply the move to.  A copy of the board is returned</param>
    let ApplyMove move board =
        let position = move.Position
        let piece = move.Piece
        if position < MinBoardIndex || position > MaxBoardIndex then raise (ArgumentOutOfRangeException "position out of bounds")
        let mapper position' piece' = 
            match position' with
            | position' when position' = position && piece' <> E -> failwith (sprintf "Position not available.  Occupied by %A" piece')
            | position' when position' = position                -> piece
            | _                                                  -> piece'
        board |> List.mapi mapper

    /// <summary>
    /// Get all the horizontal, vertical, and diagonal rows on the board. The data is
    /// returned as pairs of positions with corresponding pairs of pieces at the positions.
    ///</summary>
    let GetRows (board : Piece list) =
        match board with
        | a::b::c::d::e::f::g::h::i::[] ->
            [(0,1,2), (a,b,c)
             (3,4,5), (d,e,f)
             (6,7,8), (g,h,i)
             (0,3,6), (a,d,g)
             (1,4,7), (b,e,h)
             (2,5,8), (c,f,i)
             (0,4,8), (a,e,i)
             (2,4,6), (c,e,g)]
        | _ -> failwith "Board is invalid size"

    /// <summary>Check if all the given pieces are the same and not empty</summary>
    let inline private AreSamePiecesAndNotEmpty (a, b, c) = a <> E && a = (a &&& b &&& c)

    /// <summary>Get the winner if any for the given board.  <see cref="None" /> is returned if there is no winner</summary>
    let GetWinner board =
        match GetRows board |> Seq.map snd |> Seq.tryFind AreSamePiecesAndNotEmpty with
        | Some(winningPiece,_,_) -> Some(winningPiece)
        | _                      -> None

    /// <summary>Get the winning rows</summary>
    let GetWinningRows board =
        let inline CheckWin (_, pieces) = AreSamePiecesAndNotEmpty pieces
        GetRows board 
        |> Seq.filter CheckWin
        |> Seq.map (fun ((a,b,c),_) -> [a;b;c])

    /// <summary>Returns <c>true</c> if the game is over for the specified board; <c>false</c> if otherwise</summary>
    let IsGameOver board = (board |> Seq.exists (fun p -> p = E) |> not) || ((GetWinner board).IsSome)
    let (|Blah1|Blah2|Blah3|NoneInRow|) a = if a = 1 then Blah1(1) elif a = 2 then Blah2(2) elif a = 3 then Blah3(3) else NoneInRow(4)
    /// <summary>Evaluate the given board from the given <see cref="Piece">player's</see> perspective</summary>
    let Evaluate player board =
        let inline ScoreForPlayerPerspective playerWithPiecesInRow score = if player = playerWithPiecesInRow then score else -score
        let inline (|ThreeInARow|TwoInARow|OneInARow|ZeroInRow|) ((a, b, c) as row) =
           if AreSamePiecesAndNotEmpty row then
               ThreeInARow(ScoreForPlayerPerspective (a ||| b ||| c) 1000)
           elif (a ^^^ b ^^^ c) = E && (a ||| b ||| c) <> E && (a &&& b &&& c) = E then
               TwoInARow(ScoreForPlayerPerspective (a ||| b ||| c) 100)
           elif (a ^^^ b ^^^ c) <> E && Piece.IsDefined(typedefof<Piece>, (a ||| b ||| c)) then
               OneInARow(ScoreForPlayerPerspective (a ||| b ||| c) 10)
           else ZeroInRow
        let inline Reward row =
            match row with
            | ThreeInARow(score) -> score
            | TwoInARow(score)   -> score
            | OneInARow(score)   -> score
            | ZeroInRow          -> 0
        GetRows board |> Seq.map snd |> Seq.sumBy Reward

    /// <summary>Get the available moves for the given board</summary>
    let GetMoves player board =
        if IsGameOver board then
            // The are no moves available if the game is over
            Seq.empty
        else
            board 
            |> List.mapi (fun position piece -> position, piece) 
            |> List.filter (fun (_,piece) -> piece = E)
            |> Seq.map (fun (position,_) -> {Piece = player; Position = position})

    /// <summary>Generate a move for the given player.  <see cref="None" /> if no move could be found.</summary>
    /// <remarks>
    /// Board positions:
    /// <code>
    ///   [0;1;2;
    ///    3;4;5;
    ///    6;7;8]
    /// </code>
    /// </remarks>
    let GenerateMove ply player board =
        let moveInfo =
            match Searcher.GenerateMove {GetMoves = GetMoves; ApplyMove = ApplyMove; Evaluate = Evaluate; Opponent = Opponent } {Ply = ply} player board with
            | Some(move, score) -> Some({Move=move; Score = score})
            | None -> None
        System.Diagnostics.Debug.WriteLine(sprintf "Generated move: %A" moveInfo);
        moveInfo

    /// <summary>Run the game with using the engine to generate moves for both players.</summary>
    let rec internal Simulate ply turn board =
       printfn "%s" (ToString board)
       if IsGameOver board then
           match (GetWinner board) with
           | Some(player) -> printfn "%A wins" player
           | None         -> printfn "Tie Game"
       else
           match GenerateMove ply turn board with
           | Some(moveInfo) -> printfn "player: %A\nscore: %d" moveInfo.Move.Piece moveInfo.Score
                               Simulate ply (Opponent turn) (ApplyMove moveInfo.Move board)
           | None           -> printfn "Warning: No moves found"