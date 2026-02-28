module LambdaInterpreter

type Expr =
    | Var of string
    | Lam of string * Expr
    | App of Expr * Expr

let rec freeVars expr =
    match expr with
    | Var x -> Set.singleton x
    | Lam (x, body) ->
        freeVars body |> Set.remove x
    | App (l, r) ->
        Set.union (freeVars l) (freeVars r)

let freshVar used =
    let rec loop i =
        let name = "x" + string i
        if Set.contains name used then loop (i + 1)
        else name
    loop 0

let rec substitute x s expr =
    match expr with
    | Var y ->
        if y = x then s else Var y

    | App (l, r) ->
        App (substitute x s l, substitute x s r)

    | Lam (y, body) ->
        if y = x then
            Lam (y, body)
        else
            let fvS = freeVars s
            if Set.contains y fvS then
                let used =
                    Set.union (freeVars body) fvS
                let y' = freshVar used
                let body' = substitute y (Var y') body
                Lam (y', substitute x s body')
            else
                Lam (y, substitute x s body)

let rec reduce expr =
    match expr with
    | App (Lam (x, body), arg) ->
        substitute x arg body

    | App (l, r) ->
        let l' = reduce l
        if l' <> l then
            App (l', r)
        else
            let r' = reduce r
            if r' <> r then
                App (l, r')
            else
                expr

    | Lam (x, body) ->
        let body' = reduce body
        if body' <> body then
            Lam (x, body')
        else
            expr

    | Var _ ->
        expr

let rec normalize expr =
    let expr' = reduce expr
    if expr' = expr then expr
    else normalize expr'