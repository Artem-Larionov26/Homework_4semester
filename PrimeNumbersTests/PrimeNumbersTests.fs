module PrimeNumbersTests

open NUnit.Framework
open PrimeNumbers

[<TestFixture>]
type PrimeNumbersTests() =

    [<Test>]
    member _.``first prime is 2``() =
        Assert.That(
            primes |> Seq.head,
            Is.EqualTo(2)
        )

    [<Test>]
    member _.``first five primes``() =
        Assert.That(
            primes |> Seq.take 5 |> Seq.toList,
            Is.EqualTo([2; 3; 5; 7; 11])
        )

    [<Test>]
    member _.``first ten primes``() =
        Assert.That(
            primes |> Seq.take 10 |> Seq.toList,
            Is.EqualTo([2; 3; 5; 7; 11; 13; 17; 19; 23; 29])
        )

    [<Test>]
    member _.``100th prime``() =
        Assert.That(
            primes |> Seq.item 99,
            Is.EqualTo(541)
        )