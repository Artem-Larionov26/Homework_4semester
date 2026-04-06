module Lazy.LazyImpl

open System.Threading
open Lazy.ILazy

type SimpleLazy<'a>(supplier: unit -> 'a) =
    let mutable value : 'a option = None

    interface ILazy<'a> with
        member _.Get() =
            match value with
            | Some v -> v
            | None ->
                let v = supplier()
                value <- Some v
                v

type ThreadSafeLazy<'a>(supplier: unit -> 'a) =
    let mutable value : 'a option = None
    let lockObj = obj()

    interface ILazy<'a> with
        member _.Get() =
            match value with
            | Some v -> v
            | None ->
                lock lockObj (fun () ->
                    match value with
                    | Some v -> v
                    | None ->
                        let v = supplier()
                        value <- Some v
                        v
                )

type LockFreeLazy<'a>(supplier: unit -> 'a) =
    let mutable value : 'a option = None

    interface ILazy<'a> with
        member _.Get() =
            match value with
            | Some v -> v
            | None ->
                let newValue = supplier()

                let original =
                    Interlocked.CompareExchange(
                        &value,
                        Some newValue,
                        None
                    )

                match original with
                | None -> newValue
                | Some v -> v