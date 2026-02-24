open System

type comp_digit = {
    D : float // Действительная часть 
    M : float // Мнимая часть
}

// Функция сложения комплексных чисел
let add_digit (a : comp_digit) (b : comp_digit) : comp_digit = {
    D = a.D + b.D
    M = a.M + b.M
}

// Функция вычитания комплексных чисел
let sub_digit (a : comp_digit) (b : comp_digit) : comp_digit = {
    D = a.D - b.D  
    M = a.M - b.M
}

// Функция умножения комплексных чисел
let mul_digit (a : comp_digit) (b : comp_digit) : comp_digit = { 
    D = a.D * b.D - a.M * b.M
    M = a.D * b.M + a.M * b.D 
}

// Функция деления комплексных чисел
let div_digit (a : comp_digit) (b : comp_digit) : comp_digit =
    let d = b.D * b.D + b.M * b.M
    if d = 0 then 
         printfn "Ошибка! Деление на ноль"
         {D = 0.0; M = 0.0}
    else { 
        D = (a.D * b.D + a.M * b.M) / d
        M = (a.M * b.D - a.D * b.M) / d 
    }

// Функция возведения комплексного числа в целую степень
let rec power (c : comp_digit) (p : int) : comp_digit =
    if p = 0 then { D = 1.0; M = 0.0 }
    elif p = 1 then c
    else mul_digit c (power c (p - 1))


[<EntryPoint>]
let main args = 
    printf "Введите действительную часть первого числа: "
    let x1 = float (Console.ReadLine())
    printf "Введите мнимую часть первого числа: "
    let y1 = float (Console.ReadLine())
    let n = { D = x1; M = y1 }

    printfn (" ")

    printf "Введите действительную часть второго числа: "
    let x2 = float (Console.ReadLine())
    printf "Введите мнимую часть второго числа: "
    let y2 = float (Console.ReadLine())
    let m = { D = x2; M = y2 }

    printfn (" ")

    printfn "Выберите операцию:"
    printfn "1 - Сложение"
    printfn "2 - Вычитание"
    printfn "3 - Умножение"
    printfn "4 - Деление"
    printfn "5 - Возведение в степень"

    let ch = int (Console.ReadLine())
    printfn (" ")

    match ch with
    | 1 ->
        let sum = add_digit n m
        printfn "Сумма: %f + %fi" sum.D sum.M

    | 2 ->
        let subb = sub_digit n m
        printfn "Разность: %f + %fi" subb.D subb.M

    | 3 ->
        let mull = mul_digit n m
        printfn "Произведение: %f + %fi" mull.D mull.M

    | 4 ->
        let divv = div_digit n m
        printfn "Деление: %f + %fi" divv.D divv.M

    | 5 ->
        printf "Введите число для возведения в степень: "
        let p = int (Console.ReadLine())

        printfn (" ")

        let powa = 
            if p < 0 then
                printfn ("Степень должны быть положительная!")
                {D = 0.0; M = 0.0}
            else
                power n p

        printfn "Возведение в степень: %f %fi" powa.D powa.M

    | _ ->
        printf "Неверный номер операции! "

    0