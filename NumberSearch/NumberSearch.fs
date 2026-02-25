module NumberSearch

let findFirst (value: 'a) (list: 'a list) : int option =
    let rec loop index remaining =
        match remaining with
        | [] -> None
        | head :: tail ->
            if head = value then
                Some index
            else
                loop (index + 1) tail

    loop 0 list