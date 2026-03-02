module ParenthesisSequenceTests

open NUnit.Framework
open ParenthesisSequence

[<TestFixture>]
type BracketTests() =

    [<Test>]
    member _.``Empty string``() =
        Assert.That(isCorrect "", Is.True)

    [<Test>]
    member _.``Simple correct``() =
        Assert.That(isCorrect "()[]{}", Is.True)

    [<Test>]
    member _.``Nested correct``() =
        Assert.That(isCorrect "([{}])", Is.True)

    [<Test>]
    member _.``Incorrect order``() =
        Assert.That(isCorrect "(]", Is.False)

    [<Test>]
    member _.``Unclosed bracket``() =
        Assert.That(isCorrect "(()", Is.False)

    [<Test>]
    member _.``Extra closing``() =
        Assert.That(isCorrect "())", Is.False)

    [<Test>]
    member _.``With other characters``() =
        Assert.That(isCorrect "a(b[c]{d}e)f", Is.True)