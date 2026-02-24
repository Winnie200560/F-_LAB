// Задание №2. Рекурсия
open System
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
