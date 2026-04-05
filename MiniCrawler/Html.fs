module MiniCrawler.Html

open System.Text.RegularExpressions

let extractLinks (html: string) =
    let pattern = "<a href=\"(http://[^\"]+)\""
    Regex.Matches(html, pattern)
    |> Seq.cast<Match>
    |> Seq.map (fun m -> m.Groups[1].Value)
    |> Seq.toList