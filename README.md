# F#_LAB
# Епанова Алина, КМБ-2, Лабораторная №1
## Задание 1
### Текст задачи
Последовательно вводя числа, сформировать список из их последних цифр.
### Алгоритм решения
```
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
```
### Тестирование

<img width="1478" height="749" alt="image" src="https://github.com/user-attachments/assets/6e6e6f9b-e732-4fee-a40e-2ab73bfbcbd6" />

## Задание 2
### Текст задачи
Найти минимальную цифру натурального числа.
### Алгоритм решения
```
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


