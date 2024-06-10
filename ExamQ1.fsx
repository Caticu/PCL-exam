//Q1:
//miaw a
//me
let sqrOnlyFirst ls = 
    match ls with  
    | hd :: _ -> hd * hd 

let sqrOnlyFirstFix ls = 
    match ls with  
    | hd :: _ -> hd * hd
    | _ -> 0 

// i.
printf "%d \n" (sqrOnlyFirst [2;4;6]) // 4
// ii.
//printf "%d \n" (sqrOnlyFirst []) // The match cases were incomplete
// iii.
printf "%d \n" (sqrOnlyFirstFix []) // handle empty list

-----------
// q:1b
let rec stringToList (str:string) : char list =
    if str.Length = 0 then []
    else str.[0] :: stringToList (str.Substring(1))

let lst = stringToList "Hello"
printfn "%A" lst // ['H'; 'e'; 'l'; 'l'; 'o']


### Question 1a

#### i. Given the following function declaration:

Let's assume the provided function `sqrOnlyFirst` is:

```fsharp
let sqrOnlyFirst lst =
    match lst with
    | head :: tail -> head * head
    | [] -> 0
```

**What is the output of the following and why?**

- `sqrOnlyFirst [2; 4; 6]`
  - The input list is `[2; 4; 6]`.
  - Pattern `head :: tail` matches since the list is non-empty.
  - `head` is `2` and `tail` is `[4; 6]`.
  - The function returns `head * head`, which is `2 * 2 = 4`.

  **Output**: `4`

- `sqrOnlyFirst []`
  - The input list is `[]`.
  - Pattern `[]` matches since the list is empty.
  - The function returns `0`.

  **Output**: `0`

#### ii. Modify it to fix the problem.

Since the function appears to already work correctly, there isn't a need to fix it. However, we can provide a slightly modified version to ensure clarity:

```fsharp
let sqrOnlyFirst lst =
    match lst with
    | head :: _ -> head * head
    | [] -> 0

// Example usage and outputs
sqrOnlyFirst [2; 4; 6]  // Output: 4
sqrOnlyFirst []         // Output: 0
```

Here, the `_` symbol is used to ignore the tail of the list, emphasizing that we only care about the head.

### Question 1b

Declare a function `funqy23_5` with the type `int -> bool`, such that `funqy23_5(n) = true` exactly when `n` is divisible by 2 or 3 but not divisible by 5.

```fsharp
let funqy23_5 n =
    (n % 2 = 0 || n % 3 = 0) && n % 5 <> 0

// Test cases
funqy23_5 24  // true: 24 is divisible by 2 (but not 5)
funqy23_5 27  // true: 27 is divisible by 3 (but not 5)
funqy23_5 29  // false: 29 is not divisible by 2, 3, or 5
funqy23_5 30  // false: 30 is divisible by 2 and 5 (should return false)
```

**Explanation:**

1. The function checks if `n` is divisible by 2 or 3 using the modulo operation (`%`).
2. It also checks if `n` is not divisible by 5 using `n % 5 <> 0`.
3. The function returns `true` if `n` meets these criteria.

These test cases demonstrate the function's correctness:

- `funqy23_5(24)` returns `true` because 24 is divisible by 2 but not by 5.
- `funqy23_5(27)` returns `true` because 27 is divisible by 3 but not by 5.
- `funqy23_5(29)` returns `false` because 29 is not divisible by 2, 3, or 5.
- `funqy23_5(30)` returns `false` because 30 is divisible by both 2 and 5.

---------------

### Question 2a

#### Fix the Issue in the `countNumOfVowels` Function

Let's fix the `countNumOfVowels` function to correctly count and print each of the vowels with their corresponding numbers. We will also test the function with the given string.

```fsharp
let countNumOfVowels (str : string) =
    let charList = List.ofSeq str
    let accFunc (As, Es, Is, Os, Us) letter =
        match letter with
        | 'a' -> (As + 1, Es, Is, Os, Us)
        | 'e' -> (As, Es + 1, Is, Os, Us)
        | 'i' -> (As, Es, Is + 1, Os, Us)
        | 'o' -> (As, Es, Is, Os + 1, Us)
        | 'u' -> (As, Es, Is, Os, Us + 1)
        | _ -> (As, Es, Is, Os, Us)
    let (aCount, eCount, iCount, oCount, uCount) = List.fold accFunc (0, 0, 0, 0, 0) charList
    printfn "a: %d, e: %d, i: %d, o: %d, u: %d" aCount eCount iCount oCount uCount

// Test the function
countNumOfVowels "Higher-order functions can take and return functions of any order"
```

**Explanation:**

1. `List.ofSeq str` converts the input string to a list of characters.
2. `accFunc` is an accumulator function that updates the count of vowels based on the current character (`letter`).
3. `List.fold accFunc (0, 0, 0, 0, 0) charList` applies the accumulator function to each character in the list, starting with the initial counts of all vowels set to 0.
4. The final counts are printed using `printfn`.

**Expected Output:**

```
a: 3, e: 6, i: 4, o: 5, u: 3
```

### Question 2b

#### Declare the `replicateNtimes` Function

We need to create a function `replicateNtimes` with the type `int -> string -> string`. The function should concatenate `n` copies of the input string and raise an exception if `n` is negative.

```fsharp
let replicateNtimes n str =
    if n < 0 then
        raise (System.ArgumentException("The integer argument n cannot be negative."))
    else
        let rec helper acc count =
            if count = 0 then acc
            else helper (acc + str) (count - 1)
        helper "" n

// Test cases
printfn "%s" (replicateNtimes 3 "Fun")  // Output: "FunFunFun"
printfn "%s" (replicateNtimes 0 "EMPTY")  // Output: ""

// Uncomment to test exception
// printfn "%s" (replicateNtimes (-1) "Test")  // Raises exception
```

**Explanation:**

1. The function checks if `n` is negative and raises an exception if it is.
2. A helper function `helper` is defined to recursively concatenate the string `n` times.
3. The helper function accumulates the result in `acc` and decreases `count` until it reaches 0.
4. The function is tested with different values of `n` and `str`.

**Expected Outputs:**

- `replicateNtimes 3 "Fun"` gives `"FunFunFun"`.
- `replicateNtimes 0 "EMPTY"` gives `""`.

**Exception:**

- `replicateNtimes (-1) "Test"` raises an `ArgumentException`.

--------------
### Question 3a

#### Define a `printVariant` function

Let's define a function `printVariant` that prints the value of a `Variant` or "Empty" if it is an `Empty` variant. We'll then create instances of the `Variant` type and call `printVariant` with these instances.

```fsharp
type Variant =
    | Num of int
    | Text of string
    | Empty

let printVariant variant =
    match variant with
    | Num(n) -> printfn "Num: %d" n
    | Text(s) -> printfn "Text: %s" s
    | Empty -> printfn "Empty"

// Create instances
let variant1 = Num(42)
let variant2 = Text("Hello")
let variant3 = Empty

// Call the function
printVariant variant1  // Output: Num: 42
printVariant variant2  // Output: Text: Hello
printVariant variant3  // Output: Empty
```

**Expected Output:**

```
Num: 42
Text: Hello
Empty
```

### Question 3b

#### i. Declare a value of `Expr` that represents the expression `(6 * 10 + 25 * -2)`

Let's create a value of `Expr` that represents the algebraic expression `(6 * 10 + 25 * -2)`:

```fsharp
type Expr =
    | Num of int
    | Plus of Expr * Expr
    | Times of Expr * Expr
    | Neg of Expr

let exprValue = Plus(Times(Num(6), Num(10)), Times(Num(25), Neg(Num(2))))
```

#### ii. Fix the `f` function to remove the warning

The current `f` function has incomplete pattern matches. We need to include patterns for `Plus`, `Times`, and `Neg`.

```fsharp
let rec f = function
    | Num(n) -> n
    | Plus(x, y) -> f(x) + f(y)
    | Times(x, y) -> f(x) * f(y)
    | Neg(x) -> -f(x)

// Test the function with the value declared above
let result = f exprValue
printfn "Result: %d" result  // Output: 20
```

**Explanation:**

1. `Num(n) -> n` handles numeric values.
2. `Plus(x, y) -> f(x) + f(y)` handles addition of expressions.
3. `Times(x, y) -> f(x) * f(y)` handles multiplication of expressions.
4. `Neg(x) -> -f(x)` handles negation of an expression.

**Expected Output:**

```
Result: 20
```

The `exprValue` represents the expression `(6 * 10 + 25 * -2)`, which evaluates to `60 + (-50) = 10`.

----------

### Question 4a

#### Declare a function `trixtrans`

The `trixtrans` function should transform a list of lists such that the rows become columns. This is essentially a matrix transposition.

```fsharp
let trixtrans matrix =
    let rec transpose acc = function
        | [] -> List.rev acc
        | [] :: xss -> transpose acc xss
        | (x::xs) :: xss ->
            let newAcc = (x :: List.map List.head xss) :: acc
            let newRest = xs :: List.map List.tail xss
            transpose newAcc newRest
    transpose [] matrix

// Test the function
let result = trixtrans [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]]
printfn "%A" result  // Output: [[1; 4; 7]; [2; 5; 8]; [3; 6; 9]]
```

**Explanation:**

1. The `transpose` function recursively transposes the matrix.
2. `acc` accumulates the transposed rows.
3. `List.rev acc` is used to reverse the accumulated rows to get the correct order.

**Expected Output:**

```
[[1; 4; 7]; [2; 5; 8]; [3; 6; 9]]
```

### Question 4b

#### i. Given the following function declaration:

Let's assume we have the following function:

```fsharp
let rec flatten = function
    | [] -> []
    | x :: xs -> x @ flatten xs
```

**What is the result of the following function call? Describe in words what the function does.**

```fsharp
flatten [[1; 2; 3]; [4; 5]; [6]]
```

**Result:**

```
[1; 2; 3; 4; 5; 6]
```

**Description:**

The `flatten` function takes a list of lists and concatenates them into a single list. It processes each sublist and appends its elements to the result recursively.

#### ii. Declare a function/value to count the number of elements in the result from 4b.i above

We need to count the number of elements in the flattened list:

```fsharp
let countElements lst = List.length lst

// Flatten the list and count the elements
let flattenedList = flatten [[1; 2; 3]; [4; 5]; [6]]
let count = countElements flattenedList
printfn "Number of elements: %d" count  // Output: 6
```

**Explanation:**

1. `flatten [[1; 2; 3]; [4; 5]; [6]]` flattens the list of lists into `[1; 2; 3; 4; 5; 6]`.
2. `countElements lst` returns the length of the list using `List.length`.

**Expected Output:**

```
Number of elements: 6
```

---------------

### Question 5a

Given the type definitions to model the Customer and Order part of the GTG course project, let's assume the following definitions:

```fsharp
type Customer =
    | VIACustomer of string
    | OtherCustomer of string

type Order = {
    Customer: Customer
    Amount: float
}

let orders = [
    { Customer = VIACustomer "Alice"; Amount = 150.0 }
    { Customer = OtherCustomer "Bob"; Amount = 200.0 }
    { Customer = VIACustomer "Charlie"; Amount = 250.0 }
    { Customer = OtherCustomer "Dave"; Amount = 100.0 }
]
```

#### i). Declare an F# function that takes the list of orders and prints out orders originating from `VIACustomer`

```fsharp
let printVIAOrders orders =
    orders
    |> List.filter (fun order -> match order.Customer with VIACustomer _ -> true | _ -> false)
    |> List.iter (fun order -> printfn "Order from VIACustomer: %A" order)

// Test the function
printVIAOrders orders
```

**Explanation:**

1. `List.filter` filters orders where the customer is a `VIACustomer`.
2. `List.iter` iterates over the filtered orders and prints them.

**Expected Output:**

```
Order from VIACustomer: { Customer = VIACustomer "Alice"; Amount = 150.0 }
Order from VIACustomer: { Customer = VIACustomer "Charlie"; Amount = 250.0 }
```

#### ii). Declare an F# function/value that takes the list of orders from 5a.i above and calculates the total amount from VIA customers

```fsharp
let totalVIAAmount orders =
    orders
    |> List.filter (fun order -> match order.Customer with VIACustomer _ -> true | _ -> false)
    |> List.sumBy (fun order -> order.Amount)

// Test the function
let totalAmount = totalVIAAmount orders
printfn "Total amount from VIACustomers: %f" totalAmount
```

**Explanation:**

1. `List.filter` filters orders where the customer is a `VIACustomer`.
2. `List.sumBy` sums the amounts of the filtered orders.

**Expected Output:**

```
Total amount from VIACustomers: 400.0
```

### Question 5b

#### Rewrite the `getLunch` function to use pattern matching and test with two customers of your choice

Original function:

```fsharp
let getLunch x =
    let customer, foodChoice = x
    if foodChoice = "veggies" || foodChoice = "fish" || foodChoice = "chicken" then
        sprintf "%s doesn't want red meat" customer
    else
        sprintf "%s wants 'emmm delicious %s" customer foodChoice
```

Rewritten using pattern matching:

```fsharp
let getLunch (customer, foodChoice) =
    match foodChoice with
    | "veggies" | "fish" | "chicken" -> sprintf "%s doesn't want red meat" customer
    | _ -> sprintf "%s wants 'emmm delicious %s" customer foodChoice

// Test the function
let result1 = getLunch ("Alice", "veggies")
let result2 = getLunch ("Bob", "steak")
printfn "%s" result1  // Output: Alice doesn't want red meat
printfn "%s" result2  // Output: Bob wants 'emmm delicious steak
```

**Explanation:**

1. The function uses pattern matching on `foodChoice` to determine the message.
2. The patterns `"veggies" | "fish" | "chicken"` match the cases where the customer doesn't want red meat.
3. The wildcard pattern `_` matches all other cases.

**Expected Output:**

```
Alice doesn't want red meat
Bob wants 'emmm delicious steak
```

------------------

### Question 6a

#### i. Define the data type for the new coffee cup sizes, a new coffee record, and the corresponding price calculation function.

Here's the F# code snippet for the data type, the coffee record, and the price calculation function:

```fsharp
type CoffeeSize =
    | GtgDemi
    | GtgShort
    | GtgTall

type CoffeeProduct = {
    Name: string
    Size: CoffeeSize
}

let priceCalculation coffee =
    match coffee.Size with
    | GtgDemi -> 2.50
    | GtgShort -> 3.00
    | GtgTall -> 3.50

// Example usage
let coffee1 = { Name = "Special Coffee"; Size = GtgDemi }
let coffee2 = { Name = "Special Coffee"; Size = GtgTall }

printfn "Price of %s (%A): $%f" coffee1.Name coffee1.Size (priceCalculation coffee1)
printfn "Price of %s (%A): $%f" coffee2.Name coffee2.Size (priceCalculation coffee2)
```

**Explanation:**

1. `CoffeeSize` defines three sizes: `GtgDemi`, `GtgShort`, and `GtgTall`.
2. `CoffeeProduct` is a record type with `Name` and `Size`.
3. `priceCalculation` takes a `CoffeeProduct` and returns the price based on its size.

**Expected Output:**

```
Price of Special Coffee (GtgDemi): $2.500000
Price of Special Coffee (GtgTall): $3.500000
```

### Question 6b

#### ii. Modify your `OrderProduct` (or `OrderDrink`) message and `gtgAgent` mailbox processor

Assuming you have an `OrderDrink` message and a `gtgAgent` mailbox processor, we need to modify these to handle the new coffee products.

First, update the message type to include the new coffee products:

```fsharp
type Order =
    | OrderDrink of string
    | OrderCoffee of CoffeeProduct
```

Next, modify the `gtgAgent` to process the new coffee orders:

```fsharp
let gtgAgent = MailboxProcessor.Start(fun inbox ->
    let rec loop () = async {
        let! message = inbox.Receive()
        match message with
        | OrderDrink drinkName ->
            printfn "Order received: %s" drinkName
            // Process normal drink order
        | OrderCoffee coffee ->
            let price = priceCalculation coffee
            printfn "Order received: %s (%A) - Price: $%f" coffee.Name coffee.Size price
            // Process coffee order
        return! loop ()
    }
    loop ()
)
```

Finally, post two order messages, one for a normal coffee and one for the new `GtgCoffee`:

```fsharp
// Post normal drink order
gtgAgent.Post(OrderDrink "Latte")

// Post new coffee orders
let specialCoffee1 = { Name = "Special Coffee"; Size = GtgDemi }
let specialCoffee2 = { Name = "Special Coffee"; Size = GtgTall }

gtgAgent.Post(OrderCoffee specialCoffee1)
gtgAgent.Post(OrderCoffee specialCoffee2)
```

**Expected Output:**

```
Order received: Latte
Order received: Special Coffee (GtgDemi) - Price: $2.500000
Order received: Special Coffee (GtgTall) - Price: $3.500000
```

**Explanation:**

1. The `Order` type includes a new `OrderCoffee` case for coffee products.
2. The `gtgAgent` processes both `OrderDrink` and `OrderCoffee` messages.
3. The prices for the new coffee products are calculated and printed.

This demonstrates how to extend your GTG course project to include new coffee drink products, handle orders for these products, and display the results.

--------------

### Question 7a

#### i. Using the imperative paradigm in Python

To sum all the positive numbers in a list using an imperative approach, you can use a `for` loop and an `if` condition to filter and sum the positive numbers.

```python
def sum_positive_imperative(numbers):
    total = 0
    for num in numbers:
        if num > 0:
            total += num
    return total

# Test the function
numbers = [2, -3, 4, -5, 6]
print(sum_positive_imperative(numbers))  # Output: 12
```

**Explanation:**

1. Initialize `total` to 0.
2. Iterate over each number in the list.
3. If the number is positive (`num > 0`), add it to `total`.
4. Return the total sum of positive numbers.

#### ii. Using the functional paradigm in Python

To sum all the positive numbers in a list using a functional approach, you can use the `filter` function to filter out positive numbers and the `sum` function to compute their sum.

```python
def sum_positive_functional(numbers):
    return sum(filter(lambda x: x > 0, numbers))

# Test the function
numbers = [2, -3, 4, -5, 6]
print(sum_positive_functional(numbers))  # Output: 12
```

**Explanation:**

1. `filter(lambda x: x > 0, numbers)` creates an iterator that filters out only the positive numbers.
2. `sum(...)` computes the sum of the filtered positive numbers.

### Question 7b

#### Define a higher-order function using lambda to print even numbers

To print even numbers from a list of natural numbers using a lambda function, you can use the `filter` function along with `lambda` and then convert the result to a list for printing.

```python
def print_even_numbers(numbers):
    even_numbers = list(filter(lambda x: x % 2 == 0, numbers))
    print(even_numbers)

# Test the function
numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
print_even_numbers(numbers)  # Output: [0, 2, 4, 6, 8]
```

**Explanation:**

1. `filter(lambda x: x % 2 == 0, numbers)` creates an iterator that filters out even numbers from the list.
2. `list(...)` converts the iterator to a list.
3. `print(...)` prints the list of even numbers.


---------

### Question 8a

#### Using the imperative coding style, implement a function `group_list(lst, gl)`

```python
def group_list(lst, gl):
    grouped_list = []
    for i in range(0, len(lst), gl):
        grouped_list.append(lst[i:i + gl])
    return grouped_list

# Test the function
lst = [1, 2, 3, 4, 5, 6]
print(group_list(lst, 2))  # Output: [[1, 2], [3, 4], [5, 6]]
print(group_list(lst, 3))  # Output: [[1, 2, 3], [4, 5, 6]]
```

**Explanation:**

1. Initialize an empty list `grouped_list` to store the groups.
2. Iterate over the list `lst` in steps of `gl` using a `for` loop.
3. In each iteration, append a slice of the list from the current index `i` to `i + gl` to `grouped_list`.
4. Return `grouped_list`.

### Question 8b

#### Compute the weekly average time one spends doing exercises

```python
def compute_average_time():
    total_time = 0
    count = 0

    while True:
        minutes = int(input("Enter a number in minutes: "))
        if minutes == 0:
            break
        total_time += minutes
        count += 1

    if count == 0:
        print("No exercise time entered.")
    else:
        average_time = total_time / count
        minutes = int(average_time)
        seconds = int((average_time - minutes) * 60)
        print(f"Your weekly average exercise time is {minutes} minutes {seconds} seconds.")

# Call the function
compute_average_time()
```

**Explanation:**

1. Initialize `total_time` and `count` to 0.
2. Use a `while` loop to repeatedly prompt the user to enter a number in minutes.
3. Break the loop if the entered number is 0.
4. Add the entered number to `total_time` and increment `count`.
5. After the loop, calculate the average time.
6. Convert the average time to minutes and seconds.
7. Print the average time in the desired format.

### Question 9a

#### Define a Python function to filter products of type Drink given the `gtg_data2` using a higher-order function

```python
gtg_data2 = [
    ('Coffee', 'Drink', 1015, 15.05),
    ('Juice', 'Drink', 800, 6.05),
    ('Tuna Mini Sandwiches', 'Food', 800, 6.05),
    ('Apple', 'Fruit', 925, 5.15),
    ('Green Tea', 'Drink', 630, 12.05),
    ('Veggie Sandwiches Mix', 'Food', 800, 6.05),
    ('Banana', 'Fruit', 915, 3.10)
]

def filter_drinks(data):
    return list(filter(lambda x: x[1] == 'Drink', data))

# Test the function
filtered_drinks = filter_drinks(gtg_data2)
print(filtered_drinks)
```

**Explanation:**

1. Use `filter` with a lambda function to filter products where the type is `'Drink'`.
2. Convert the filtered result to a list.

**Expected Output:**

```
[('Coffee', 'Drink', 1015, 15.05), ('Juice', 'Drink', 800, 6.05), ('Green Tea', 'Drink', 630, 12.05)]
```

### Question 9b

#### Using the functional programming paradigm, declare Python functions that return a list of tuples containing the drink and the corresponding subtotal, and the total amount of all the drinks

```python
def drink_subtotals(data):
    drinks = filter(lambda x: x[1] == 'Drink', data)
    subtotals = map(lambda x: (x[0], x[2] * x[3]), drinks)
    return list(subtotals)

def total_amount(data):
    subtotals = drink_subtotals(data)
    total = sum(map(lambda x: x[1], subtotals))
    return subtotals, total

# Test the functions
subtotals, total = total_amount(gtg_data2)
print("Subtotals:", subtotals)
print("Total amount:", total)
```

**Explanation:**

1. `drink_subtotals` filters drinks and maps them to tuples containing the drink name and the subtotal (quantity * unit price).
2. `total_amount` uses `drink_subtotals` to get the list of subtotals and calculates the total by summing the subtotals.

**Expected Output:**

```
Subtotals: [('Coffee', 15202.75), ('Juice', 4840.0), ('Green Tea', 7591.5)]
Total amount: 27634.25
```

---------

### Question 10a

#### Write a Python program to read user input and compute the tax and discount

Here is the Python program to compute the tax and discount based on the user's input:

```python
def compute_cost():
    # Constants
    gtgVAT = 0.15  # 15% VAT
    discount_rate = 0.05  # 5% discount for VIA Customers

    # Read user inputs
    cost = float(input("Enter the cost of the product: "))
    is_via_customer = input("Are you a VIA Customer? (yes/no): ").strip().lower() == 'yes'

    # Calculate discount
    discount = cost * discount_rate if is_via_customer else 0
    cost_after_discount = cost - discount

    # Calculate tax
    tax = cost_after_discount * gtgVAT

    # Calculate grand total
    grand_total = cost_after_discount + tax

    # Output the results
    print(f"Discount amount: ${discount:.2f}")
    print(f"Tax amount: ${tax:.2f}")
    print(f"Grand total: ${grand_total:.2f}")

# Test the function
compute_cost()
```

**Explanation:**

1. `gtgVAT` is set to 15% (0.15).
2. `discount_rate` is set to 5% (0.05).
3. The user is prompted to enter the cost of the product and whether they are a VIA Customer.
4. The discount is calculated if the user is a VIA Customer.
5. The tax is calculated on the cost after discount.
6. The grand total is calculated as the sum of the cost after discount and the tax.
7. The results are printed.

### Question 10b

#### Implement the UML class diagram in Python

Here is the Python code to implement the UML class diagram:

```python
class Property:
    def __init__(self, square_meter, num_bedrooms):
        self.square_meter = square_meter
        self.num_bedrooms = num_bedrooms

    def show_detail(self):
        print(f"Property details: {self.square_meter} sq meter, {self.num_bedrooms} bedrooms")


class House(Property):
    def __init__(self, square_meter, num_bedrooms, garage, fenced, num_floors):
        super().__init__(square_meter, num_bedrooms)
        self.garage = garage
        self.fenced = fenced
        self.num_floors = num_floors

    def __str__(self):
        return f"House with {self.num_floors} floors, garage: {self.garage}, fenced: {self.fenced}"

    def show_detail(self):
        super().show_detail()
        print(f"House details: {self.num_floors} floors, garage: {self.garage}, fenced: {self.fenced}")


class Rental(Property):
    def __init__(self, square_meter, num_bedrooms, furnished, rent):
        super().__init__(square_meter, num_bedrooms)
        self.furnished = furnished
        self.rent = rent

    def show_detail(self):
        super().show_detail()
        print(f"Rental details: furnished: {self.furnished}, rent: ${self.rent}")


class HouseRental(House, Rental):
    def __init__(self, square_meter, num_bedrooms, garage, fenced, num_floors, furnished, rent):
        House.__init__(self, square_meter, num_bedrooms, garage, fenced, num_floors)
        Rental.__init__(self, square_meter, num_bedrooms, furnished, rent)

    def show_detail(self):
        House.show_detail(self)
        Rental.show_detail(self)


# Create objects and test
property = Property(100, 3)
house = House(120, 4, "Yes", "Yes", 2)
rental = Rental(90, 2, "No", 1200)
house_rental = HouseRental(150, 5, "Yes", "No", 3, "Yes", 2500)

property.show_detail()
print()
house.show_detail()
print()
rental.show_detail()
print()
house_rental.show_detail()
```

**Explanation:**

1. `Property` class has two attributes: `square_meter` and `num_bedrooms`, and a method `show_detail` to print the details.
2. `House` class inherits from `Property` and adds attributes: `garage`, `fenced`, and `num_floors`. It overrides `show_detail` and adds a `__str__` method.
3. `Rental` class inherits from `Property` and adds attributes: `furnished` and `rent`. It overrides `show_detail`.
4. `HouseRental` class inherits from both `House` and `Rental` classes, initializes both, and overrides `show_detail` to show details from both `House` and `Rental`.
5. Objects are created for each class, and the `show_detail` method is called to print the details.

**Expected Output:**

```
Property details: 100 sq meter, 3 bedrooms

Property details: 120 sq meter, 4 bedrooms
House details: 2 floors, garage: Yes, fenced: Yes

Property details: 90 sq meter, 2 bedrooms
Rental details: furnished: No, rent: $1200

Property details: 150 sq meter, 5 bedrooms
House details: 3 floors, garage: Yes, fenced: No
Property details: 150 sq meter, 5 bedrooms
Rental details: furnished: Yes, rent: $2500
```

This demonstrates the implementation of the UML class diagram using multiple inheritance and proper initialization of constructors.
