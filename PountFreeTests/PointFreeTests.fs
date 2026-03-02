module PointFreeTests

open NUnit.Framework
open FsCheck
open FsCheck.NUnit
open NUnit.Framework.Legacy
open PointFree

[<TestFixture>]
type PointFreeTests() =

    [<Test>]
    member _.``Simple example``() =
        let result = func 3 [1;2;3]
        CollectionAssert.AreEqual([3;6;9], result)

    [<Property>]
    member _.``Point-free version equals original`` (x:int) (l:int list) =
        funcOriginal x l = func x l