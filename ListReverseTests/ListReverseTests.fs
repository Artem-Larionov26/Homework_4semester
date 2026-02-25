module ListReverseTests

open NUnit.Framework
open ListReverse

[<TestFixture>]
type ReverseTests() =

    [<Test>]
    member _.``empty list``() =
        Assert.That(reverse [], Is.EqualTo([]))

    [<Test>]
    member _.``single element``() =
        Assert.That(reverse [1], Is.EqualTo([1]))

    [<Test>]
    member _.``multiple elements``() =
        Assert.That(reverse [1;2;3], Is.EqualTo([3;2;1]))

    [<Test>]
    member _.``string list``() =
        Assert.That(
            reverse ["a"; "b"; "c"],
            Is.EqualTo(["c"; "b"; "a"])
        )