module MiniCrawler.Program

open MiniCrawler.Crawler

[<EntryPoint>]
let main _ =
    printf "Enter URL: "
    let url = System.Console.ReadLine()

    let results =
        crawl url
        |> Async.RunSynchronously

    results
    |> List.iter (fun (url, size) ->
        printfn "%s — %d" url size
    )

    0