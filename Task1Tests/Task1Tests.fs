module Task1Tests

open NUnit.Framework
open FsUnit
open Task1

[<Test>]
let ``min of list`` () =
    minElement [3; 1; 4; 2] |> should equal 1

[<Test>]
let ``single element`` () =
    minElement [5] |> should equal 5

[<Test>]
let ``negative numbers`` () =
    minElement [-3; -1; -10] |> should equal -10

[<Test>]
let ``empty list throws`` () =
    (fun () -> minElement [] |> ignore)
    |> should throw typeof<System.Exception>
