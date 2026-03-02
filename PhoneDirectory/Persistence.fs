module PhoneDirectory.Persistence

open PhoneDirectory.Domain
open System.IO

let saveToFile path book =
    book
    |> List.map (fun e -> $"{e.Name};{e.Phone}")
    |> fun lines -> File.WriteAllLines(path, lines)

let loadFromFile path =
    if File.Exists path then
        File.ReadAllLines path
        |> Array.toList
        |> List.map (fun line ->
            let parts = line.Split ';'
            { Name = parts[0]; Phone = parts[1] }
        )
    else
        []