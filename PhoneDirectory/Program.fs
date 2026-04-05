open PhoneDirectory.Domain
open PhoneDirectory.Persistence

let readInput () =
    System.Console.ReadLine().Trim()

let rec loop book =
    printfn ""
    printfn "Commands:"
    printfn "add <name> <phone>"
    printfn "find-name <name>"
    printfn "find-phone <phone>"
    printfn "show"
    printfn "save <path>"
    printfn "load <path>"
    printfn "exit"

    let input = readInput()

    match input.Split ' ' |> Array.toList with
    | ["add"; name; phone] ->
        loop (add name phone book)

    | ["find-name"; name] ->
        match findByName name book with
        | Some phone -> printfn $"Phone: {phone}"
        | None -> printfn "Not found"
        loop book

    | ["find-phone"; phone] ->
        match findByPhone phone book with
        | Some name -> printfn $"Name: {name}"
        | None -> printfn "Not found"
        loop book

    | ["show"] ->
        book |> List.iter (fun e -> printfn $"{e.Name} - {e.Phone}")
        loop book

    | ["save"; path] ->
        match saveToFile path book with
        | Ok () -> printfn "Saved"
        | Error e -> printfn $"Error: {e}"
        loop book

    | ["load"; path] ->
        match loadFromFile path with
        | Ok newBook -> loop newBook
        | Error e ->
            printfn $"Error: {e}"
            loop book

    | ["exit"] ->
        ()

    | _ ->
        printfn "Invalid command"
        loop book

loop empty