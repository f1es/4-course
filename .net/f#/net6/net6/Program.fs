
//1. Создайте два варианта функции, которая возвращает кортеж
//   значений. Первый вариант принимает на вход параметры в виде
//   кортежа, второй вариант параметры в каррированном виде.

let tupleFunction (a, b) =
    let sum = a + b
    let product = a * b
    (sum, product)

let curriedFunction a b =
    let sum = a + b
    let product = a * b
    (sum, product)

//2. Выберите простой алгоритм, который может быть реализован в
//   виде рекурсивной функции и реализуйте его в F#. Пример –
//   вычисление суммы целых чисел в заданном диапазоне.

let rec sumRange start finish =
    if start > finish then 0
    else start + sumRange (start + 1) finish

//3. Преобразуйте разработанную рекурсивную функцию в форму
//   хвостовой рекурсии.

let sumRangeTailRec start finish =
    let rec loop acc current =
        if current > finish then acc
        else loop (acc + current) (current + 1)
    loop 0 start

//4. По аналогии с пунктом 3.7.4 разработайте конечный автомат из
//   трех состояний и реализуйте его в виде взаимно-рекурсивных
//   функций.

type State = 
    | State1
    | State2
    | State3

let rec state1 input =
    match input with
    | 1 -> state2 input
    | _ -> state1 input

and state2 input =
    match input with
    | 2 -> state3 input
    | _ -> state2 input

and state3 input =
    match input with
    | 3 -> state1 input
    | _ -> state3 input

let initialState = State1

//5. На основе пунктов 3.7.7 и 3.7.8 разработайте функцию, которая
//   принимает 3 целых числа и лямбда-выражение для их
//   суммирования в виде кортежа и в каррированном виде.
let sumTupleFunction (a, b, c) lambda =
    lambda a b c
let lambdaSum = fun x y z -> x + y + z
let tupleResult = sumTupleFunction (1, 2, 3) lambdaSum


let sumCurriedFunction a b c lambda =
    lambda a b c
let curriedResult = sumCurriedFunction 1 2 3 lambdaSum