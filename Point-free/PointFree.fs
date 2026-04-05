module PointFree

// The original function
let multiplyEachByOriginal x l =
    List.map (fun y -> y * x) l

// Withdrawal Steps:
//
// multiplyEachByOriginal x l = List.map (fun y -> y * x) l
// => multiplyEachByOriginal x = List.map (fun y -> y * x)
// => fun y -> y * x = (*) x
// => multiplyEachByOriginal x = List.map ((*) x)
// => multiplyEachBy = List.map << (*)

let multiplyEachBy =
    List.map << (*)