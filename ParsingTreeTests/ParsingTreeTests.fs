module ParsingTreeTests

open NUnit.Framework
open ParsingTree

[<TestFixture>]
type ExpressionTreeTests() =

    [<Test>]
    member _.``constant``() =
        Assert.That(eval (Const 5), Is.EqualTo(5))

    [<Test>]
    member _.``simple addition``() =
        Assert.That(
            eval (Add(Const 2, Const 3)),
            Is.EqualTo(5)
        )

    [<Test>]
    member _.``nested expression``() =
        let expr =
            Mul(
                Add(Const 2, Const 3),
                Const 4
            )
        Assert.That(eval expr, Is.EqualTo(20))

    [<Test>]
    member _.``inorder linearization``() =
        let expr =
            Mul(
                Add(Const 2, Const 3),
                Const 4
            )

        let result = inorder expr

        Assert.That(
            result,
            Is.EqualTo(["2"; "+"; "3"; "*"; "4"])
        )