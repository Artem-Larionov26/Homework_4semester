module NumberSearchTests

open NUnit.Framework
open NumberSearch

[<TestFixture>]
type SearchTests() =

    [<Test>]
    member _.``element found at beginning``() =
        Assert.That(findFirst 1 [1;2;3], Is.EqualTo(Some 0))

    [<Test>]
    member _.``element found in middle``() =
        Assert.That(findFirst 2 [1;2;3], Is.EqualTo(Some 1))

    [<Test>]
    member _.``element found at end``() =
        Assert.That(findFirst 3 [1;2;3], Is.EqualTo(Some 2))

    [<Test>]
    member _.``element not found``() =
        Assert.That(findFirst 4 [1;2;3], Is.EqualTo(None))

    [<Test>]
    member _.``empty list``() =
        Assert.That(findFirst 1 [], Is.EqualTo(None))