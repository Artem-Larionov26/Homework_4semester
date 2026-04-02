module Task2Tests

open NUnit.Framework
open FsUnit
open Task2

[<Test>]
let ``square of size 4`` () =
    printSquare 4 |> should equal "****\n*  *\n*  *\n****"

[<Test>]
let ``square of size 1`` () =
    printSquare 1 |> should equal "*"

[<Test>]
let ``square of size 2`` () =
    printSquare 2 |> should equal "**\n**"