module FactorialTests

open NUnit.Framework
open Factorial

[<TestFixture>]
type FactorialTests() =

    [<Test>]
    member _.``0! = 1``() =
        Assert.That(factorial 0, Is.EqualTo(1I))

    [<Test>]
    member _.``1! = 1``() =
        Assert.That(factorial 1, Is.EqualTo(1I))

    [<Test>]
    member _.``5! = 120``() =
        Assert.That(factorial 5, Is.EqualTo(120I))

    [<Test>]
    member _.``10! = 3628800``() =
        Assert.That(factorial 10, Is.EqualTo(3628800I))

    [<Test>]
    member _.``negative argument throws``() =
        Assert.That(
            (fun () -> factorial -1 |> ignore),
            Throws.TypeOf<System.ArgumentException>()
        )