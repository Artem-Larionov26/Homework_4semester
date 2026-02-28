module LambdaInterpreterTests

open LambdaInterpreter
open NUnit.Framework

[<TestFixture>]
type LambdaTests() =

    let v x = Var x
    let lam x b = Lam (x, b)
    let app l r = App (l, r)

    [<Test>]
    member _.``Identity reduces correctly``() =
        let id = lam "x" (v "x")
        let expr = app id (v "y")
        let result = normalize expr
        Assert.That(result, Is.EqualTo(v "y"))

    [<Test>]
    member _.``K combinator works``() =
        let k = lam "x" (lam "y" (v "x"))
        let expr = app (app k (v "a")) (v "b")
        let result = normalize expr
        Assert.That(result, Is.EqualTo(v "a"))

    [<Test>]
    member _.``SKK equals I``() =
        let s =
            lam "x" (
                lam "y" (
                    lam "z" (
                        app (app (v "x") (v "z"))
                            (app (v "y") (v "z"))
                    )
                )
            )

        let k = lam "x" (lam "y" (v "x"))
        let expr = app (app s k) k
        let result = normalize expr

        Assert.That(result, Is.EqualTo(lam "z" (v "z")))

    [<Test>]
    member _.``Alpha conversion avoids capture``() =
        let expr =
            app
                (lam "x" (lam "y" (v "x")))
                (v "y")

        let result = normalize expr

        match result with
        | Lam (name, body) ->
            Assert.That(body, Is.EqualTo(v "y"))
            Assert.That(name <> "y")
        | _ ->
            Assert.Fail("Expected lambda")

    [<Test>]
    member _.``Alpha conversion deeper case``() =
        let expr =
            app
                (lam "x" (lam "y" (app (v "x") (v "y"))))
                (v "y")

        let result = normalize expr

        match result with
        | Lam (name, body) ->
            Assert.That(name <> "y")
        | _ ->
            Assert.Fail("Expected lambda")