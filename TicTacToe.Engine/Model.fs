namespace TicTacToe.Engine
open System

/// <summary>The available pieces, <c>X</c> and <c>O</c>, along with the empty piece indicator, <c>E</c></summary>
[<Flags>]
type Piece = | E = 0 | X = 1 | O = 2

/// <summary>A tic-tac-toe move</summary>
type Move = {Piece : Piece; Position : int}

/// <summary>A scored move</summary>
type MoveInfo = {Move : Move; Score : int}

module internal Model =
    /// <summary>The X piece.  Shorthand for <see cref="Piece.X" /></summary>
    let [<Literal>] X = Piece.X

    /// <summary>The O piece.  Shorthand for <see cref="Piece.O" /></summary>
    let [<Literal>] O = Piece.O

    /// <summary>The empty piece.  Shorthand for <see cref="Piece.E" /></summary>
    let [<Literal>] E = Piece.E

    /// <summary>The minimum index position on a tic-tac-toe board</summary>
    let [<Literal>] MinBoardIndex = 0

    /// <summary>The maximum index position on a tic-tac-toe board</summary>
    let [<Literal>] MaxBoardIndex = 8