module Task1

/// Returns the minimum element of a list.
/// Throws an exception if the list is empty
let minElement list =
    match list with
    | [] -> failwith "Empty list"
    | head :: tail ->
        List.fold (fun acc x -> if x < acc then x else acc) head tail
