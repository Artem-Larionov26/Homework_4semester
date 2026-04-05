module PhoneDirectoryTests

open NUnit.Framework
open System.IO
open PhoneDirectory.Persistence
open PhoneDirectory.Domain

[<TestFixture>]
type DomainTests() =

    [<Test>]
    member _.``Add and find by name``() =
        let book =
            empty
            |> add "Alice" "123"

        let result = findByName "Alice" book
        Assert.That(result, Is.EqualTo(Some "123"))

    [<Test>]
    member _.``Find by phone``() =
        let book =
            empty
            |> add "Bob" "999"

        let result = findByPhone "999" book
        Assert.That(result, Is.EqualTo(Some "Bob"))

    [<Test>]
    member _.``Not found returns None``() =
        let book = empty
        let result = findByName "X" book
        Assert.That(result, Is.EqualTo(None))

    [<Test>]
    member _.``Get all entries``() =
        let book =
            empty
            |> add "A" "1"
            |> add "B" "2"

        let result = getAll book
        Assert.That(result.Length, Is.EqualTo(2))

    [<Test>]
    member _.``Save and load works``() =
        let path = "test.txt"

        let book =
            empty
            |> add "Alice" "123"

        match saveToFile path book with
        | Error e -> Assert.Fail(e)
        | Ok () -> ()

        match loadFromFile path with
        | Error e -> Assert.Fail(e)
        | Ok loaded ->
            Assert.That(loaded, Is.EqualTo(book))

        File.Delete path

    [<Test>]
    member _.``Load non-existing file returns error``() =
        let result = loadFromFile "no_such_file.txt"
        match result with
        | Ok _ -> Assert.Fail("Expected error")
        | Error _ -> Assert.Pass()