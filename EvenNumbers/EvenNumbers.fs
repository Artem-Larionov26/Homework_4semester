module EvenNumbers

let countEvenFilter (list: int list) : int =
    list
    |> List.filter (fun x -> x % 2 = 0)
    |> List.length

let countEvenMap (list: int list) : int =
    list
    |> List.map (fun x -> if x % 2 = 0 then 1 else 0)
    |> List.sum

let countEvenFold (list: int list) : int =
    list
    |> List.fold (fun acc x ->
        if x % 2 = 0 then acc + 1 else acc) 0