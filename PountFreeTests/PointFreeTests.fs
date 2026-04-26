module PointFreeTests

open NUnit.Framework
open FsUnit
open FsCheck.NUnit
open PointFree

[<Test>]
let ``simple example`` () =
    pointFree 3 [1; 2; 3] |> should equal [3; 6; 9]

[<Property>]
let ``point-free version equals original`` (x: int) (l: int list) =
    originalFunction x l = pointFree x l

[<Property>]
let ``all derivation steps are equivalent`` (x: int) (l: int list) =
    originalFunction x l = withoutListArgument x l
    && originalFunction x l = withOperator x l
    && originalFunction x l = withFlip x l
    && originalFunction x l = pointFree x l