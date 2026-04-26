module LambdaInterpreter

type Expr =
    | Var of string
    | Lam of string * Expr
    | App of Expr * Expr

let rec freeVars =
    function
    | Var x -> Set.singleton x
    | Lam (x, body) -> freeVars body |> Set.remove x
    | App (left, right) -> Set.union (freeVars left) (freeVars right)

let rec vars =
    function
    | Var x -> Set.singleton x
    | Lam (x, body) -> Set.add x (vars body)
    | App (left, right) -> Set.union (vars left) (vars right)

let freshVar used =
    let rec loop index =
        let name = "x" + string index
        if Set.contains name used then loop (index + 1)
        else name

    loop 0

let rec substitute x substitution =
    function
    | Var y when y = x -> substitution
    | Var y -> Var y

    | App (left, right) ->
        App (substitute x substitution left, substitute x substitution right)

    | Lam (y, body) when y = x ->
        Lam (y, body)

    | Lam (y, body) ->
        let freeSubstitutionVars = freeVars substitution
        let freeBodyVars = freeVars body

        if Set.contains y freeSubstitutionVars && Set.contains x freeBodyVars then
            let usedVars =
                Set.union (vars body) (vars substitution)

            let newName = freshVar usedVars
            let renamedBody = substitute y (Var newName) body

            Lam (newName, substitute x substitution renamedBody)
        else
            Lam (y, substitute x substitution body)

let rec reduce =
    function
    | App (Lam (x, body), argument) ->
        substitute x argument body

    | App (left, right) ->
        let reducedLeft = reduce left

        if reducedLeft <> left then
            App (reducedLeft, right)
        else
            App (left, reduce right)

    | Lam (x, body) ->
        Lam (x, reduce body)

    | Var x ->
        Var x

let rec normalize maxSteps expr =
    if maxSteps = 0 then
        None
    else
        let reduced = reduce expr

        if reduced = expr then
            Some expr
        else
            normalize (maxSteps - 1) reduced