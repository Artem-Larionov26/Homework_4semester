module TreeMapTests

open NUnit.Framework
open TreeMap

[<TestFixture>]
type TreeMapTests() =

    let sampleTree =
        Node(1,
            Node(2, Empty, Empty),
            Node(3, Empty, Empty))

    [<Test>]
    member _.``map doubles values``() =
        let result = map (fun x -> x * 2) sampleTree

        let expected =
            Node(2,
                Node(4, Empty, Empty),
                Node(6, Empty, Empty))

        Assert.That(result, Is.EqualTo(expected))

    [<Test>]
    member _.``map on empty tree``() =
        let result = map ((+) 1) Empty
        let expected : Tree<int> = Empty
        Assert.That(result, Is.EqualTo(expected))