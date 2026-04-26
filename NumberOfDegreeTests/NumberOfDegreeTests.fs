module NumberOfDegreeTests

open NUnit.Framework
open FsUnit
open NumberOfDegree

[<Test>]
let ``n = 0 and m = 0`` () =
    powersOfTwo 0 0
    |> should equal (Ok [1.0] : Result<float list, string>)

[<Test>]
let ``n = 1 and m = 3`` () =
    powersOfTwo 1 3
    |> should equal (Ok [2.0; 4.0; 8.0; 16.0] : Result<float list, string>)

[<Test>]
let ``n = 3 and m = 2`` () =
    powersOfTwo 3 2
    |> should equal (Ok [8.0; 16.0; 32.0] : Result<float list, string>)

[<Test>]
let ``negative m returns error`` () =
    powersOfTwo 2 -1
    |> should equal (Error "m must be non-negative" : Result<float list, string>)