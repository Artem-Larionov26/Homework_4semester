open PhoneDirectory.Domain
open PhoneDirectory.Persistence

let rec loop book =
    printfn ""
    printfn "1. Add"
    printfn "2. Find by name"
    printfn "3. Find by phone"
    printfn "4. Show all"
    printfn "5. Save"
    printfn "6. Load"
    printfn "0. Exit"

    match System.Console.ReadLine() with
    | "1" ->
        printf "Name: "
        let name = System.Console.ReadLine()
        printf "Phone: "
        let phone = System.Console.ReadLine()
        loop (add name phone book)

    | "2" ->
        printf "Name: "
        let name = System.Console.ReadLine()
        match findByName name book with
        | Some phone -> printfn $"Phone: {phone}"
        | None -> printfn "Not found"
        loop book

    | "3" ->
        printf "Phone: "
        let phone = System.Console.ReadLine()
        match findByPhone phone book with
        | Some name -> printfn $"Name: {name}"
        | None -> printfn "Not found"
        loop book

    | "4" ->
        getAll book
        |> List.iter (fun e -> printfn $"{e.Name} - {e.Phone}")
        loop book

    | "5" ->
        printf "File path: "
        let path = System.Console.ReadLine()
        saveToFile path book
        loop book

    | "6" ->
        printf "File path: "
        let path = System.Console.ReadLine()
        let newBook = loadFromFile path
        loop newBook

    | "0" ->
        ()

    | _ ->
        printfn "Invalid option"
        loop book

[<EntryPoint>]
let main _ =
    loop empty
    0