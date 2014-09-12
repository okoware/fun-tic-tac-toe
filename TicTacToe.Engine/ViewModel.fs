namespace TicTacToe.Engine
open System
open System.ComponentModel
open System.Windows.Input

/// Types of players.  Human or Computer
type PlayerType = | Human = 0 | Computer = 1

/// The game states
type GameState = | PreStart = 0 | Started = 1 | GameOver = 2

module private CommandUtility =
    /// <summary>Create a <see cref="ICommand">command</see> with the given action</summary>
    let CreateCommand canExecute action =
        //let canExecuteChangedEvent = new Event<_,_>()
        {
            new ICommand with
                //[<CLIEvent>]
                //member this.CanExecuteChanged = canExecuteChangedEvent.Publish
                member this.CanExecute obj = canExecute obj
                member this.Execute obj = if (canExecute obj) then action obj
                member this.add_CanExecuteChanged handler = CommandManager.RequerySuggested.AddHandler handler
                member this.remove_CanExecuteChanged handler = CommandManager.RequerySuggested.RemoveHandler handler
        }

module ViewModelProperties =
    /// <summary>Property names for <see cref="TicTacToeViewModel" /></summary>
    module TicTacToeViewModel =
        let [<Literal>] Board = "Board"
        let [<Literal>] CurrentPlayer = "CurrentPlayer"
        let [<Literal>] GameState = "GameState"
        let [<Literal>] PlayerX = "PlayerX"
        let [<Literal>] PlayerO = "PlayerO"
        let [<Literal>] StatusMessage = "StatusMessage"
        let [<Literal>] TimePerMove = "TimePerMove"
    /// <summary>Property names for <see cref="PlayerViewModel" /></summary>
    module PlayerViewModel =
        let [<Literal>] PlayerType = "PlayerType"
        let [<Literal>] Ply = "Ply"
        let [<Literal>] WinCount = "WinCount"
        let [<Literal>] RemainingMoveTime = "RemainingMoveTime"


/// <summary>
/// The player view model
/// </summary>
[<System.Diagnostics.DebuggerDisplay("{PlayerType} {OwnedPiece};")>]
type PlayerViewModel (ownedPiece, playerType, ply) =
    let mutable playerType = playerType
    let mutable ply = ply
    let mutable winCount = 0
    let mutable remainingMoveTime = TimeSpan.FromSeconds 0.
    let propChangedEvent = new DelegateEvent<PropertyChangedEventHandler>()
    interface INotifyPropertyChanged with 
        [<CLIEvent>]
        member x.PropertyChanged = propChangedEvent.Publish

    /// <summary>Get the piece owned by this player</summary>
    member this.OwnedPiece = ownedPiece

    /// <summary>Get the ply</summary>
    member this.PlayerType
        with get() = playerType
        and set(value) =
           playerType <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.PlayerViewModel.PlayerType)|])

    /// <summary>Get the ply</summary>
    member this.Ply
        with get() = ply
        and set(value) =
           ply <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.PlayerViewModel.Ply)|])

    /// <summary>Get the win count</summary>
    member this.WinCount
        with get() = winCount
        and internal set(value) =
           winCount <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.PlayerViewModel.WinCount)|])

    /// <summary>Get the win count</summary>
    member this.RemainingMoveTime
        with get() = remainingMoveTime
        and internal set(value) =
           remainingMoveTime <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.PlayerViewModel.RemainingMoveTime)|])

/// <summary>
/// The tic-tac-toe view model
/// </summary>
type TicTacToeViewModel () as this =
    let playerX = new PlayerViewModel(Piece.X, PlayerType.Human, 3us)
    let playerO = new PlayerViewModel(Piece.O, PlayerType.Computer, 3us)
    let mutable board = TicTacToeEngine.EmptyBoard
    let mutable currentPlayer = playerX
    let mutable gameStartPlayer = playerX
    let mutable gameState = GameState.PreStart
    let mutable statusMessage = String.Empty
    let mutable timePerMove = TimeSpan.FromSeconds 3.
    let mutable selectedMove = None
    let mutable computerMoveInProgress = false
    let propChangedEvent = new DelegateEvent<PropertyChangedEventHandler>()
    let Opponent playerInfo = if playerInfo = playerX then playerO else playerX
    let GetPlayerByPiece = function | Some(Piece.X) -> Some(playerX) | Some(Piece.O) -> Some(playerO) | _ -> None
    let mutable cancellationTokenSource : System.Threading.CancellationTokenSource option = None
    let mutable timerInterval = TimeSpan.FromSeconds 1.
    let timer = new System.Threading.Timer(new System.Threading.TimerCallback(this.timer_callback))

    interface INotifyPropertyChanged with 
        [<CLIEvent>]
        member x.PropertyChanged = propChangedEvent.Publish

    /// <summary>Get tailured message based on if the current player is the only human player/summary>
    member private this.GetTailoredMessage humanText computerText (playerInfo : PlayerViewModel) =
        match playerInfo.PlayerType, (Opponent playerInfo).PlayerType with
        | PlayerType.Human, PlayerType.Computer -> humanText
        | _, _                                  -> computerText

    /// <summary>Get the view model for player X</summary>
    member this.PlayerXViewModel = playerX

    /// <summary>Get the view model for player O</summary>
    member this.PlayerOViewModel = playerO

    /// <summary>Get the current board state</summary>
    member this.Board
        with get() = board
        and private set(value) =
           board <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.TicTacToeViewModel.Board)|])

    /// <summary>Get the player with the current turn</summary>
    member this.CurrentPlayer
        with get() = currentPlayer
        and private set(value) =
           currentPlayer <- value

    /// <summary>Get the game state</summary>
    member this.GameState
        with get() = gameState
        and private set(value) =
           gameState <- value
           if gameState = GameState.GameOver then
               this.StatusMessage <- match TicTacToeEngine.GetWinner this.Board with
                                     | Some(winner) -> (sprintf "Player %A Won" winner)
                                     | None         -> "Tie game"
           else
               this.StatusMessage <- sprintf "%A" gameState
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.TicTacToeViewModel.GameState)|])
           
    /// <summary>Get the game status message</summary>
    member this.StatusMessage
        with get() = statusMessage
        and private set(value) =
           statusMessage <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.TicTacToeViewModel.StatusMessage)|])

    /// <summary>Get the current board state</summary>
    member this.TimePerMove
        with get() = timePerMove
        and set(value) =
           timePerMove <- value
           propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.TicTacToeViewModel.TimePerMove)|])
           
    /// <summary>Get the winning rows</summary>
    member this.WinningRows = TicTacToeEngine.GetWinningRows board

    /// <summary>Set the selected move.  This is usually for human input.</summary>
    member this.SelectedMovePosition
        with set(value) = selectedMove <- Some({ Piece = currentPlayer.OwnedPiece; Position = value })

    /// <summary>Notify player of turn</summary>
    member private this.NotifyPlayerTurn () =
        this.StatusMessage <- (this.GetTailoredMessage "your turn" (sprintf "Turn: %A" this.CurrentPlayer.OwnedPiece) this.CurrentPlayer)
        propChangedEvent.Trigger([|this; new PropertyChangedEventArgs(ViewModelProperties.TicTacToeViewModel.CurrentPlayer)|])
        (Opponent this.CurrentPlayer).RemainingMoveTime <- TimeSpan.Zero
        this.CurrentPlayer.RemainingMoveTime <- this.TimePerMove
        timer.Change(timerInterval, timerInterval) |> ignore
        if this.CurrentPlayer.PlayerType = PlayerType.Computer then
            this.GenerateComputerMove ()

    /// <summary>Alternate player turn</summary>
    member private this.SwapTurn () =
        this.CurrentPlayer <- Opponent this.CurrentPlayer

    /// <summary>Update game end statistics</summary>
    member private this.UpdateGameEndStats () =
        match GetPlayerByPiece (TicTacToeEngine.GetWinner board) with
        | Some(winner) -> winner.WinCount <- winner.WinCount + 1
        | None         -> ()

    /// <summary>Apply the given move to the board</summary>
    member private this.ApplyMove move =
        try
            this.StopTimer ()
            this.Board <- TicTacToeEngine.ApplyMove move board
            computerMoveInProgress <- false
            if TicTacToeEngine.IsGameOver(board) then
                this.UpdateGameEndStats();
                this.GameState <- GameState.GameOver
            else
                this.SwapTurn ()
                this.NotifyPlayerTurn ()
        with
            | ex -> System.Diagnostics.Debug.WriteLine ex.Message
    
    /// <summary>Auto start the game if it hasn't been started or the game is over</summary>
    member private this.AutoStart () =
        if gameState = GameState.PreStart then
            this.StartGame () // auto start game
            if gameStartPlayer.PlayerType = PlayerType.Human && gameState = GameState.Started && selectedMove.IsSome then
                // Ensure that the selected move is attributed to the player with the current turn
                this.SelectedMovePosition <- selectedMove.Value.Position
                // Apply the move that the user selected already
                this.ApplySelectedMove ()
        elif gameState = GameState.GameOver then
            this.StartRound () // auto start round

    /// <summary>Apply the selected move if available.  The <see cref="SelectedMovePosition">selected move</see> comes from the owner of this view model.</summary>
    member private this.ApplySelectedMove () =
        if gameState = GameState.Started && this.CurrentPlayer.PlayerType = PlayerType.Human && gameState = GameState.Started && selectedMove.IsSome then
            this.ApplyMove selectedMove.Value
        else
            this.AutoStart ()

    /// <summary>Generate a computer move and apply it to the board</summary>
    member private this.GenerateComputerMove () =
        computerMoveInProgress <- true
        cancellationTokenSource <- Some(new System.Threading.CancellationTokenSource())
        let cancellationToken = cancellationTokenSource.Value.Token
        let task = async {
            match TicTacToeEngine.GenerateMove this.CurrentPlayer.Ply currentPlayer.OwnedPiece board with
            | Some(moveInfo) ->
                if not cancellationToken.IsCancellationRequested then
                    this.ApplyMove moveInfo.Move
            | None -> ()
            computerMoveInProgress <- false
        }
        Async.Start (task, cancellationToken)

    /// <summary>
    /// Determines if the player with the current turn is a human or computer.  It delegates human players to <see cref="ApplySelectedMove" />
    /// and computer players to <see cref="GenerateComputerMove" />.
    /// </summary>
    member private this.MakePlayerMove () =
        if this.CurrentPlayer.PlayerType = PlayerType.Human then this.ApplySelectedMove () else this.GenerateComputerMove ()

    /// <summary>Stop the timer</summary>
    member private this.StopTimer () =
        timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite) |> ignore

    /// <summary>Cancel the current computer move</summary>
    member private this.CancelCurrentComputerMove () =
        if cancellationTokenSource.IsSome && cancellationTokenSource.Value.Token.CanBeCanceled then
            cancellationTokenSource.Value.Cancel ()
            computerMoveInProgress <- false

    /// <summary>Callback for the move timer</summary>
    member private this.timer_callback _ =
        let timeRemaining = this.CurrentPlayer.RemainingMoveTime.Subtract(timerInterval)
        this.CurrentPlayer.RemainingMoveTime <- timeRemaining
        if timeRemaining <= TimeSpan.Zero then
            this.StopTimer ()
            this.CancelCurrentComputerMove ()
            this.SwapTurn ()
            this.NotifyPlayerTurn ()

    /// <summary>Start the game</summary>
    member private this.StartGame () =
        this.StopTimer ()
        this.CancelCurrentComputerMove ()
        this.Board <- TicTacToeEngine.EmptyBoard
        this.GameState <- GameState.Started
        this.CurrentPlayer <- gameStartPlayer
        this.NotifyPlayerTurn ()

    /// <summary>Reset the game state and board</summary>
    member private this.StartRound () =
        gameStartPlayer <- Opponent gameStartPlayer
        this.StartGame ()

    /// <summary>Reset the game state and board</summary>
    member private this.ResetGame () =
        playerX.WinCount <- 0
        playerO.WinCount <- 0
        gameStartPlayer <- playerX
        this.StartGame ()

    /// <summary>Command for invoking human moves</summary>
    member this.HumanMoveCommand =
        CommandUtility.CreateCommand
            (fun _ -> not computerMoveInProgress)
            (fun _ -> this.ApplySelectedMove ())

    /// <summary>Command for starting game</summary>
    member this.StartGameCommand =
        CommandUtility.CreateCommand
            (fun _ -> true)
            (fun _ -> this.StartGame())

    /// <summary>Command for starting a new round</summary>
    member this.StartRoundCommand =
        CommandUtility.CreateCommand
            (fun _ -> not computerMoveInProgress && gameState = GameState.GameOver)
            (fun _ -> this.StartRound())

    /// <summary>Command for reseting game</summary>
    member this.ResetGameCommand =
        CommandUtility.CreateCommand
            (fun _ -> true)
            (fun _ -> this.ResetGame())