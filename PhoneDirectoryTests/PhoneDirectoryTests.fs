module PhoneDirectoryTests

open NUnit.Framework
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