module ParsingTree

type Expr =
    | Const of int
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

let rec eval expr =
    match expr with
    | Const value -> value
    | Add (l, r) -> eval l + eval r
    | Sub (l, r) -> eval l - eval r
    | Mul (l, r) -> eval l * eval r
    | Div (l, r) -> eval l / eval r

let rec linearize expr =
    seq {
        match expr with
        | Const v ->
            yield string v
        | Add (l, r) ->
            yield! linearize l
            yield "+"
            yield! linearize r
        | Sub (l, r) ->
            yield! linearize l
            yield "-"
            yield! linearize r
        | Mul (l, r) ->
            yield! linearize l
            yield "*"
            yield! linearize r
        | Div (l, r) ->
            yield! linearize l
            yield "/"
            yield! linearize r
    }

let inorder expr =
    linearize expr |> Seq.toList