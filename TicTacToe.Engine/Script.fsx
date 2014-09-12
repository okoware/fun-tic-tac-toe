// This file is a script that can be executed with the F# Interactive.  
// It can be used to explore and test the library project.
// Note that script files will not be part of the project build.

#load "Model.fs"
#load "Searcher.fs"
#load "TicTacToeEngine.fs"
open TicTacToe.Engine.Model
open TicTacToe.Engine.TicTacToeEngine

printfn "%s" (ToString [X;O;X; O;X;O; X;E;X])

[X;E;X; E;O;E; O;E;X] |> GenerateMove  2us O
[E;E;E; E;E;E; E;E;E] |> Simulate 5us X