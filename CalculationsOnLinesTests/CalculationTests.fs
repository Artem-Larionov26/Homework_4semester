module CalculationsOnLinesTests

open NUnit.Framework
open FsUnit
open CalculationsOnLines.Calculation

[<Test>]
let ``Correct strings should sum`` () =
    let result =
        calculate {
            let! x = "1"
            let! y = "2"
            return x + y
        }

    result |> should equal (Some 3)

[<Test>]
let ``Invalid string should return None`` () =
    let result =
        calculate {
            let! x = "1"
            let! y = "abc"
            return x + y
        }

    result |> should equal None

[<Test>]
let ``Single value works`` () =
    let result =
        calculate {
            let! x = "5"
            return x
        }

    result |> should equal (Some 5)

[<Test>]
let ``Multiple operations work`` () =
    let result =
        calculate {
            let! x = "2"
            let! y = "3"
            let! z = "4"
            return x + y + z
        }

    result |> should equal (Some 9)

[<Test>]
let ``ReturnFrom works`` () =
    let result =
        calculate {
            return! Some 10
        }

    result |> should equal (Some 10)