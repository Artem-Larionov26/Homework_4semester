module NumberOfDegreeTests

open NUnit.Framework
open NumberOfDegree

[<TestFixture>]
type PowerSeriesTests() =

    [<Test>]
    member _.``n=0 m=0``() =
        Assert.That(
            powersOfTwo 0 0,
            Is.EqualTo(Ok [1.0] : Result<float list, string>)
        )

    [<Test>]
    member _.``n=1 m=3``() =
        Assert.That(
            powersOfTwo 1 3,
            Is.EqualTo(Ok [2.0; 4.0; 8.0; 16.0] : Result<float list, string>)
        )

    [<Test>]
    member _.``n=3 m=2``() =
        Assert.That(
            powersOfTwo 3 2,
            Is.EqualTo(Ok [8.0; 16.0; 32.0] : Result<float list, string>)
        )

    [<Test>]
    member _.``negative m returns error``() =
        Assert.That(
            powersOfTwo 2 -1,
            Is.EqualTo(Error "m must be non-negative" : Result<float list, string>)
    )