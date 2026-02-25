module FibonacciTests

open Fibonacci
open NUnit.Framework

[<TestFixture>]
type FibonacciTests() =

    [<Test>]
    member _.``fib 0 = 0``() =
        Assert.That(fib 0, Is.EqualTo(0I))

    [<Test>]
    member _.``fib 1 = 1``() =
        Assert.That(fib 1, Is.EqualTo(1I))

    [<Test>]
    member _.``fib 5 = 5``() =
        Assert.That(fib 5, Is.EqualTo(5I))

    [<Test>]
    member _.``fib 10 = 55``() =
        Assert.That(fib 10, Is.EqualTo(55I))

    [<Test>]
    member _.``negative argument throws``() =
        Assert.That(
            (fun () -> fib -1 |> ignore),
            Throws.TypeOf<System.ArgumentException>()
        )