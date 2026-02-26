module EvenNumbersTests

open NUnit.Framework
open FsCheck
open FsCheck.NUnit
open EvenNumbers

[<TestFixture>]
type EvenNumbersTests() =

    [<Test>]
    member _.``empty list``() =
        Assert.That(countEvenFilter [], Is.EqualTo(0))

    [<Test>]
    member _.``simple example``() =
        Assert.That(countEvenFilter [1;2;3;4], Is.EqualTo(2))

    [<Property>]
    member _.``filter and map equivalent`` (xs: int list) =
        countEvenFilter xs = countEvenMap xs

    [<Property>]
    member _.``filter and fold equivalent`` (xs: int list) =
        countEvenFilter xs = countEvenFold xs