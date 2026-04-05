module MiniCrawler.Crawler

open System.Net.Http
open MiniCrawler.Html


let httpClient = new HttpClient()

let downloadAsync (url: string) =
    async {
        try
            let! html = httpClient.GetStringAsync(url) |> Async.AwaitTask
            return Some (url, html)
        with _ ->
            return None
    }

let crawl url =
    async {
        let! mainPage = downloadAsync url

        match mainPage with
        | None -> return []
        | Some (_, html) ->
            let links = extractLinks html |> List.distinct

            let! results =
                links
                |> List.map downloadAsync
                |> Async.Parallel

            return
                results
                |> Array.choose id
                |> Array.map (fun (url, html) -> (url, html.Length))
                |> Array.toList
    }