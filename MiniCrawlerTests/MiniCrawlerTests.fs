module MiniCrawlerTests

open NUnit.Framework
open MiniCrawler.Html

[<Test>]
let ``Extract single link`` () =
    let html = "<a href=\"http://a.com\">A</a>"
    let result = extractLinks html
    Assert.That(result, Is.EqualTo(["http://a.com"]))

[<Test>]
let ``Extract multiple links`` () =
    let html = "<a href=\"http://a.com\">A</a><a href=\"http://b.com\">B</a>"
    let result = extractLinks html
    Assert.That(result, Is.EqualTo(["http://a.com"; "http://b.com"]))

[<Test>]
let ``Ignore non-http links`` () =
    let html = "<a href=\"https://a.com\">A</a>"
    let result = extractLinks html
    Assert.That(result, Is.Empty)

[<Test>]
let ``No links returns empty list`` () =
    let html = "<html></html>"
    let result = extractLinks html
    Assert.That(result, Is.Empty)

[<Test>]
let ``Handles broken html safely`` () =
    let html = "<a href=\"http://a.com\">"
    let result = extractLinks html
    Assert.That(result, Is.EqualTo(["http://a.com"]))
