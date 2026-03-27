module RoundingWorkflowTests

open NUnit.Framework
open FsUnit
open RoundingWorkflow.Rounding

[<Test>]
let ``Rounding works correctly`` () =
    let result =
        rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }

    result |> should equal 0.048

[<Test>]
let ``Intermediate rounding works`` () =
    let result =
        rounding 2 {
            let! a = 10.0 / 3.0
            let! b = 3.0
            return a / b
        }

    result |> should equal 1.11

[<Test>]
let ``Return is rounded`` () =
    let result =
        rounding 2 {
            return 1.234
        }

    result |> should equal 1.23

[<Test>]
let ``Multiple operations rounding`` () =
    let result =
        rounding 2 {
            let! a = 1.0 / 3.0
            let! b = 2.0 / 3.0
            return a + b
        }

    result |> should equal 1.0

[<Test>]
let ``ReturnFrom works`` () =
    let result =
        rounding 2 {
            return! 1.236
        }

    result |> should equal 1.24