module LazyTests

open NUnit.Framework
open System.Threading.Tasks
open Lazy.ILazy
open Lazy.LazyImpl

let runBasicTests (create: (unit -> int) -> ILazy<int>) =
    let lazyVal = create (fun () -> 42)

    let v1 = lazyVal.Get()
    let v2 = lazyVal.Get()

    Assert.That(v1, Is.EqualTo(42))
    Assert.That(v2, Is.EqualTo(42))


let runSingleThreadTest (create: (unit -> int) -> ILazy<int>) =
    let mutable counter = 0

    let lazyVal =
        create (fun () ->
            counter <- counter + 1
            42
        )

    lazyVal.Get() |> ignore
    lazyVal.Get() |> ignore

    Assert.That(counter, Is.EqualTo(1))


let runMultiThreadTest (create: (unit -> int) -> ILazy<int>) =
    let lazyVal = create (fun () -> 42)

    let tasks =
        [1..10]
        |> List.map (fun _ ->
            Task.Run(fun () -> lazyVal.Get())
        )

    Task.WaitAll(tasks |> List.map (fun t -> t :> Task) |> Array.ofList)

    let results = tasks |> List.map (fun t -> t.Result)

    Assert.That(results |> List.forall ((=) 42), Is.True)

[<TestFixture>]
type ``SimpleLazy tests`` () =

    let create f = SimpleLazy(f) :> ILazy<_>

    [<Test>]
    member _.``Returns same value`` () =
        runBasicTests create

    [<Test>]
    member _.``Single-thread evaluation once`` () =
        runSingleThreadTest create


[<TestFixture>]
type ``ThreadSafeLazy tests`` () =

    let create f = ThreadSafeLazy(f) :> ILazy<_>

    [<Test>]
    member _.``Returns same value`` () =
        runBasicTests create

    [<Test>]
    member _.``Single-thread evaluation once`` () =
        runSingleThreadTest create

    [<Test>]
    member _.``Multi-thread correctness`` () =
        runMultiThreadTest create


[<TestFixture>]
type ``LockFreeLazy tests`` () =

    let create f = LockFreeLazy(f) :> ILazy<_>

    [<Test>]
    member _.``Returns same value`` () =
        runBasicTests create

    [<Test>]
    member _.``Single-thread evaluation once`` () =
        runSingleThreadTest create

    [<Test>]
    member _.``Multi-thread correctness`` () =
        runMultiThreadTest create