module NumberOfDegreeTests

open NUnit.Framework
open NumberOfDegree

[<TestFixture>]
type PowerSeriesTests() =

    [<Test>]
    member _.``n=0 m=0``() =
        Assert.That(powersOfTwo 0 0, Is.EqualTo([1I]))

    [<Test>]
    member _.``n=1 m=3``() =
        Assert.That(
            powersOfTwo 1 3,
            Is.EqualTo([2I; 4I; 8I; 16I])
        )

    [<Test>]
    member _.``n=3 m=2``() =
        Assert.That(
            powersOfTwo 3 2,
            Is.EqualTo([8I; 16I; 32I])
        )

    [<Test>]
    member _.``negative m throws``() =
        Assert.That(
            (fun () -> powersOfTwo 2 -1 |> ignore),
            Throws.TypeOf<System.ArgumentException>()
        ) 