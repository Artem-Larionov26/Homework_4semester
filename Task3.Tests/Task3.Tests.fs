module Task3Tests

open NUnit.Framework
open FsUnit
open Task3

let hash x = x % 10

[<Test>]
let ``add and contains`` () =
    let table = HashTable<int>(10, hash)
    table.Add(5)
    table.Contains(5) |> should equal true

[<Test>]
let ``remove element`` () =
    let table = HashTable<int>(10, hash)
    table.Add(5)
    table.Remove(5)
    table.Contains(5) |> should equal false

[<Test>]
let ``collision handling`` () =
    let table = HashTable<int>(10, hash)
    table.Add(5)
    table.Add(15)
    table.Contains(5) |> should equal true
    table.Contains(15) |> should equal true

[<Test>]
let ``remove non-existing element does nothing`` () =
    let table = HashTable<int>(10, hash)
    table.Remove(42)
    table.Contains(42) |> should equal false