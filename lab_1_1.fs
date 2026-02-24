// Лабораторная №1
// Задание №1. Генерация списков
open System

let spisok x =
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
