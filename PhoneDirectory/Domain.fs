module PhoneDirectory.Domain

type Entry = {
    Name : string
    Phone : string
}

type PhoneBook = Entry list

let empty : PhoneBook = []

let add name phone book =
    { Name = name; Phone = phone } :: book

let findByName name book =
    book
    |> List.tryFind (fun e -> e.Name = name)
    |> Option.map (fun e -> e.Phone)

let findByPhone phone book =
    book
    |> List.tryFind (fun e -> e.Phone = phone)
    |> Option.map (fun e -> e.Name)

let getAll book =
    book