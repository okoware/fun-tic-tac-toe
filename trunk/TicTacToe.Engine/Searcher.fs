namespace TicTacToe.Engine
open System

module internal Searcher =
    /// <summary>Search handlers</summary>
    type SearchHandler<'state, 'player, 'move> = {
        GetMoves       : 'player -> 'state -> 'move seq 
        ApplyMove      : 'move   -> 'state -> 'state
        Evaluate       : 'player -> 'state -> int
        Opponent       : 'player -> 'player
    }

    /// <summary>Options for searcher</summary>
    type SearchOptions = {Ply : uint16}

    // <summary>Shuffle array in place</summary>
    let private KnuthShuffle (rnd : Random) (items : array<'a>) =
        let Swap i j =
            let item = items.[i]
            items.[i] <- items.[j]
            items.[j] <- item
        let itemsCount = items.Length
        [0 .. (itemsCount - 2)]
        |> Seq.iter (fun i -> Swap i (rnd.Next(i, itemsCount)))
        items

    /// <summary>Generate a move for the given player.  <see cref="None" /> if no move could be found.</summary>
    /// <returns>A tuple consisting of the move and corresponding score.  <c>('move * 'score)</c></returns>
    let GenerateMove handlers options player board =
        let originalPlayer = player
        let rnd = Random()
        let GetMovesInRandomOrder player board =
            handlers.GetMoves player board
            |> Seq.toArray |> KnuthShuffle rnd   // Shuffle the moves
        let Expand player board =
            GetMovesInRandomOrder player board
            |> Seq.map (fun move -> handlers.ApplyMove move board)
        // TODO: can be optimized with alpha beta pruning
        let rec Minimax depth player board =
            let children = Expand player board
            if depth = 0us || Seq.isEmpty children then
                //printfn "%A depth=%d; score=%d;" board depth (handlers.Evaluate originalPlayer board)
                handlers.Evaluate originalPlayer board
            else
                children
                |> Seq.map (fun child -> (Minimax (depth - 1us) (handlers.Opponent player) child))
                |> if player = originalPlayer then Seq.max else Seq.min
        let GenerateMove' player board =
            let moves = GetMovesInRandomOrder player board
            if Seq.isEmpty(moves) then None
            elif options.Ply = 0us then
               // Return available move in list if ply is set to zero (random move)
               Some((Seq.head moves), 0)
            else
                moves
                |> Seq.map (fun move -> move, Minimax (options.Ply - 1us) (handlers.Opponent player) (handlers.ApplyMove move board))
                |> Seq.maxBy (fun (move,score) -> score)
                |> Some
        GenerateMove' player board