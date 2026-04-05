module PhoneDirectory.Persistence

open PhoneDirectory.Domain
open System.IO

let saveToFile path book =
    try
        book
        |> List.map (fun e -> $"{e.Name};{e.Phone}")
        |> fun lines -> File.WriteAllLines(path, lines)
        Ok ()
    with e ->
        Error e.Message

let parseLine (line: string) =
    match line.Split ';' with
    | [| name; phone |] ->
        Ok { Name = name; Phone = phone }
    | _ ->
        Error $"Invalid line format: {line}"

let loadFromFile path =
    if not (File.Exists path) then
        Error "File does not exist"
    else
        try
            File.ReadAllLines path
            |> Array.toList
            |> List.map parseLine
            |> List.fold (fun acc elem ->
                match acc, elem with
                | Ok list, Ok entry -> Ok (entry :: list)
                | Error e, _ -> Error e
                | _, Error e -> Error e
            ) (Ok [])
            |> Result.map List.rev
        with e ->
            Error e.Message