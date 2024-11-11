open System

// Функция для решения квадратного уравнения
let solveQuadratic a b c =
    let D = b * b - 4.0 * a * c
    if D < 0.0 then
        None
    else
        let sqrtD = Math.Sqrt(D)
        let y1 = (-b + sqrtD) / (2.0 * a)
        let y2 = (-b - sqrtD) / (2.0 * a)
        Some (y1, y2)

// Основная функция
let solveBiquadratic a b c =
    if a = 0.0 then
        printfn "Это не биквадратное уравнение."
    else
        match solveQuadratic a b c with
        | None -> printfn "Корней нет."
        | Some (y1, y2) ->
            if y1 >= 0.0 then
                let x1 = Math.Sqrt(y1)
                let x2 = -Math.Sqrt(y1)
                printfn "Корни уравнения: x1 = %f, x2 = %f" x1 x2
            if y2 >= 0.0 then
                let x3 = Math.Sqrt(y2)
                let x4 = -Math.Sqrt(y2)
                printfn "Корни уравнения: x3 = %f, x4 = %f" x3 x4

// Ввод коэффициентов
printfn "Введите коэффициенты a, b и c:"
let a = Convert.ToDouble(Console.ReadLine())
let b = Convert.ToDouble(Console.ReadLine())
let c = Convert.ToDouble(Console.ReadLine())
printfn "Уравнение (x^4 * %f) + (x^2 * %f) + (%f)" a b c

// Решение биквадратного уравнения
solveBiquadratic a b c
