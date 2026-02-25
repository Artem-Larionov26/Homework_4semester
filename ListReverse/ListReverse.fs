module ListReverse

let reverse (list: 'a list) : 'a list =
    let rec loop remaining acc =
        match remaining with
        | [] -> acc
        | head :: tail ->
            loop tail (head :: acc)

    loop list []