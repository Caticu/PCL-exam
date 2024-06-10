//q3a:
let rec rerun (s: string) (n: int) : string =
    if n <= 0 then " "
    else s + rerun s (n - 1)

let result = rerun "code" 3
printf "\n%s" result
//output: codecodecode
let result2 = rerun "code" 0
printf "\n%s" result2
//output: ""

//q3b:
let rerunTailRecursive (s: string) (n: int) : string =
    let rec loop (acc: string) (count: int) =
        if count <= 0 then acc
        else loop (acc + s) (count - 1)
    loop "" n

let result3 = rerunTailRecursive "code" 3
printf "\n%s" result

printf "\n"