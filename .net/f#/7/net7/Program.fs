// For more information see https://aka.ms/fsharp-console-apps

//1. Разработайте функцию, которая принимает три параметра
//обобщенных типов и возвращает их в виде кортежа.
//Модифицируйте функцию: не указывая явно типы параметров,
//задавая выражения в теле функции, сделайте так, чтобы параметры
//были типов int, float, string.

let createTuple a b c = (a, b, c)

let createTypedTuple a b c =
    let a = a + 0  // Преобразует первый параметр в int
    let b = b + 0.0 // Преобразует второй параметр в float
    let c = c + ""  // Преобразует третий параметр в string
    (a, b, c)

//2. С использованием двухэтапного создания обобщенных 
//функций реализуйте функции, которые осуществляют сложение:
//трех аргументов типа int;
//трех аргументов типа float;
//трех аргументов типа string.

// Обобщенная функция сложения трех аргументов 
let sumThree a b c = a + b + c

// Функция сложения трех аргументов типа int 
let sumThreeInts a b c : int = 
    sumThree a b c

// Функция сложения трех аргументов типа float
let sumThreeFloats a b c : float =
    sumThree a b c


//3. С использованием list comprehension для четных элементов списка
//[1..10] верните список кортежей. Каждый кортеж содержит элемент
//списка, его квадрат и куб.

// Определяем исходный список
let numbers5 = [1..10]

// Используем list comprehension для фильтрации четных элементов и создания кортежей
let evenTuples = 
    [ for n in numbers5 do
        if n % 2 = 0 then
            yield (n, n * n, n * n * n) ]

// Выводим результат
printfn "%A" evenTuples

//4. На основе пункта 3.8.1 напишите два варианта функции, которая
//принимает на вход список и возвращает квадраты его значений.
//Необходимо использовать свойства списка Head и Tail. Первый
//вариант функции использует оператор if, второй вариант
//использует сопоставление с образцом на уровне функции.

let rec squareListIf lst =
    if List.isEmpty lst then
        []
    else
        let head = List.head lst
        let tail = List.tail lst
        (head * head) :: (squareListIf tail)

// Пример использования
let resultIf = squareListIf [1; 2; 3; 4]
printfn "%A" resultIf  // Вывод: [1; 4; 9; 16]

let rec squareListPattern lst =
    match lst with
    | [] -> []
    | head :: tail -> (head * head) :: (squareListPattern tail)

// Пример использования
let resultPattern = squareListPattern [1; 2; 3; 4]
printfn "%A" resultPattern  // Вывод: [1; 4; 9; 16]

//5. Последовательно примените к списку функции map, sort, filter, fold,
//zip, функции агрегирования. Функции применяются в любом
//порядке и произвольно используются в трех комбинациях.
//- Первая комбинация заканчивается функцией агрегирования
//(например, сумма элементов списка). Cписок предварительно
//может быть отсортирован, отфильтрован и т.д.
//- Вторая комбинация заканчивается функцией fold, которая
//осуществляет свертку списка. Вторая комбинация выполняет
//те же действия, что и первая комбинация и должна
//возвращать такой же результат.
//- Третья комбинация заканчивается функцией zip, которая
//соединяет два списка.

let numbers = [10; 5; 3; 8; 2; 7; 4; 6; 9; 1]

// Сортировка списка
let sortedNumbers = List.sort numbers

// Фильтрация четных чисел
let evenNumbers = List.filter (fun x -> x % 2 = 0) sortedNumbers

// Агрегация (сумма элементов списка)
let sum = List.sum evenNumbers

printfn "Первая комбинация - Сумма четных чисел: %d" sum

let evenNumbers2 = List.filter (fun x -> x % 2 = 0) numbers
let sortedEvenNumbers = List.sort evenNumbers2

// Используем fold для суммирования
let sumFold = List.fold (+) 0 sortedEvenNumbers

printfn "Вторая комбинация - Сумма четных чисел с использованием fold: %d" sumFold

// Создаем список кортежей (число, его квадрат)
let squaredNumbers = List.map (fun x -> (x, x * x)) numbers

// Фильтруем кортежи, где число четное
let evenSquaredNumbers = List.filter (fun (x, _) -> x % 2 = 0) squaredNumbers

// Объединяем исходный список и список квадратов с использованием zip
let zippedNumbers = List.zip numbers (List.map snd squaredNumbers)

printfn "Третья комбинация - Объединенные исходный список и квадраты: %A" zippedNumbers

//6. Реализуйте предыдущий пункт с использованием оператора потока
//« |> ».

let numbers_6 = [10; 5; 3; 8; 2; 7; 4; 6; 9; 1]

let sum_6 =
    numbers_6
    |> List.sort
    |> List.filter (fun x -> x % 2 = 0)
    |> List.sum

printfn "Первая комбинация - Сумма четных чисел: %d" sum_6

let sumFold_6 =
    numbers_6
    |> List.filter (fun x -> x % 2 = 0)
    |> List.sort
    |> List.fold (+) 0

printfn "Вторая комбинация - Сумма четных чисел с использованием fold: %d" sumFold_6

let zippedNumbers_6 =
    numbers
    |> List.map (fun x -> (x, x * x))
    |> List.filter (fun (x, _) -> x % 2 = 0)
    |> List.zip numbers

printfn "Третья комбинация - Объединенные исходный список и квадраты: %A" zippedNumbers_6

//7. Реализуйте предыдущий пункт с использованием оператора
//композиции функций « >> ».

let numbers_7 = [10; 5; 3; 8; 2; 7; 4; 6; 9; 1]

let sum_7 =
    (List.sort >> List.filter (fun x -> x % 2 = 0) >> List.sum) numbers_7

printfn "Первая комбинация - Сумма четных чисел: %d" sum_7

let sumFold_7 =
    (List.filter (fun x -> x % 2 = 0) >> List.sort >> List.fold (+) 0) numbers_7

printfn "Вторая комбинация - Сумма четных чисел с использованием fold: %d" sumFold_7

let zippedNumbers_7 =
    (List.map (fun x -> (x, x * x)) >> List.filter (fun (x, _) -> x % 2 = 0) >> List.zip numbers_7) numbers_7

printfn "Третья комбинация - Объединенные исходный список и квадраты: %A" zippedNumbers_7