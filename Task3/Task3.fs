module Task3

/// A simple hash table implementation using separate chaining
/// Uses an array of lists to handle collisions
/// Hash function is provided externally
/// Does not store duplicate elements
type HashTable<'T when 'T : equality>(size: int, hashFunc: 'T -> int) =

    /// Array of buckets (lists)
    let buckets : 'T list array = Array.init size (fun _ -> [])

    /// Calculates index in array (safe for negative hash values)
    let getIndex item =
        let hash = hashFunc item &&& System.Int32.MaxValue
        hash % size

    /// Adds an element to the hash table
    /// Does nothing if the element already exists
    member this.Add(item: 'T) =
        let index = getIndex item
        if not (this.Contains item) then
            buckets.[index] <- item :: buckets.[index]

    /// Checks if element exists in the hash table
    member this.Contains(item: 'T) =
        let index = getIndex item
        buckets.[index] |> List.exists ((=) item)

    /// Removes an element from the hash table
    /// Does nothing if the element is not present
    member this.Remove(item: 'T) =
        let index = getIndex item
        buckets.[index] <- buckets.[index] |> List.filter ((<>) item)