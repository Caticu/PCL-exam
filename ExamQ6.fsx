//Q6
// Define a record type to represent a product with a name and quantity
type Product = {
    Name: string
    Quantity: int
}
// Define a discriminated union type for messages that can be sent to the product agent
type ProductMsg =
    | AddProduct of Product
    | GetProducts of (Product list -> unit)

// Define a mailbox processor to act as an agent for managing products
let productAgent=
    MailboxProcessor.Start(fun inbox ->
        // Define a mutable list to store products
        let mutable products = []
        // Define a recursive function to handle messages received by the agent
        let rec loop () =
                async {
                    // Receive a message from the inbox
                    let! msg = inbox.Receive()
                    match msg with
                    | AddProduct product ->
                        // Add the product to the list of products
                        products <- product :: products
                    | GetProducts replyAction ->
                        // Clone the products list before passing it to the reply action
                        let clonedProducts = List.rev products
                        // Invoke the reply action with the cloned products list
                        replyAction clonedProducts
                    // Continue processing messages by recursively calling the loop function
                    return! loop ()
                }
        // Start processing messages by invoking the loop function
        loop ())

// Add products
productAgent.Post(AddProduct { Name = "Apple"; Quantity = 10 })
productAgent.Post(AddProduct { Name = "Banana"; Quantity = 20 })
productAgent.Post(AddProduct { Name = "Orange"; Quantity = 15 })

// Get products
// Request the list of products from the product agent
printfn "Inventory:"
productAgent.Post(GetProducts(fun products -> 
    products |> List.iter (fun product -> 
        printfn "%s - Quantity: %d" product.Name product.Quantity)))


//output
//Inventory:
//Apple - Quantity: 10
//Banana - Quantity: 20
//Orange - Quantity: 15
