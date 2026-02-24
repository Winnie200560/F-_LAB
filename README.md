# F#_LAB
# Епанова Алина, КМБ-2, Лабораторная №1
## Задание 1
### Текст задачи
Последовательно вводя числа, сформировать список из их последних цифр.
### Алгоритм решения
```
open System

let spisok (x : int) : int list =
    [
    for i in 1..x do
        printf "Введите число %d: " i
        let num = int (Console.ReadLine())
        yield abs (num % 10)
    ]

[<EntryPoint>]
let main args = 
    printf "Введите количество чисел для ввода: "
    let n = int (Console.ReadLine())
    if n > 0 then
        printf "Список последних цифр: %A " (spisok n) 
    else
        printfn "Ошибка! Количество должно быть положительным числом."
    0
```
### Тестирование

<img width="1478" height="749" alt="image" src="https://github.com/user-attachments/assets/6e6e6f9b-e732-4fee-a40e-2ab73bfbcbd6" />
<img width="1482" height="442" alt="image" src="https://github.com/user-attachments/assets/75316b78-d3fd-4a23-bb45-8c03106b1a2b" />


## Задание 2
### Текст задачи
Найти минимальную цифру натурального числа.
### Алгоритм решения
```
open System

// Функция для поиска минимальной цифры в числе
let rec min_d n min =
    if n = 0 then min
    else
        let digit = n % 10
        let newMin = 
            if digit < min 
            then digit 
            else min
        min_d (n / 10) newMin

[<EntryPoint>]
let main args = 
    printf "Введите число: "
    let n = int (Console.ReadLine())
    if n > 0 then
        printf "Минимальная цифра: %d" (min_d n 9)
    else
        printfn "Ошибка! Число должно быть больше нуля."
    0
```
### Тестирование

<img width="1474" height="218" alt="image" src="https://github.com/user-attachments/assets/a714f9b8-fa19-41d9-b752-6d0e95e0b683" />
<img width="1469" height="250" alt="image" src="https://github.com/user-attachments/assets/917007b4-34e7-42f0-ba10-305bab0a75d4" />

## Задание 3
### Текст задачи
Опишите функции, осуществляющие основные математические операции над комплексными
числами (сложение, вычитание, умножение, деление, возведение в степень). Использовать
готовый класс Complex запрещено.
### Алгоритм решения
```
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
```
### Тестирование
<img width="1485" height="419" alt="image" src="https://github.com/user-attachments/assets/d15f645f-f7a4-4369-ad5d-2c70ee022b1e" />
<img width="1479" height="410" alt="image" src="https://github.com/user-attachments/assets/5e09a6a2-e586-4912-be4d-a91d60debc50" />
<img width="1473" height="414" alt="image" src="https://github.com/user-attachments/assets/ec0abb1d-da47-4995-b2c9-72a0b4daed2f" />
<img width="1467" height="405" alt="image" src="https://github.com/user-attachments/assets/1d7d4a4b-9f08-4fba-91ef-ed6cb29c0f02" />
<img width="1480" height="463" alt="image" src="https://github.com/user-attachments/assets/7cd8e663-53ac-409e-8db5-889132dcd7c1" />








