import timeit

def pow_iter(number, degree):
    temp = number
    for i in range(1, degree):
        number *= temp
    return number

def pow_rec(number, n):
    if n > 1:
        return number * pow_rec(number, n - 1)
    else:
        return number

def reverse_string_iter(string):
    string_array = list(string)

    for i in range(0, int(len(string_array) / 2)):
        temp = string_array[i]
        string_array[i] = string_array[len(string_array) - 1 - i]
        string_array[len(string_array) - 1 - i] = temp
    
    return "".join(string_array)

def reverse_string_rec(string, n = 0):
    if n >= int(len(string) / 2):
        return "".join(string)
    else:
        temp = string[n]
        string[n] = string[len(string) - 1 - n]
        string[len(string) - 1 - n] = temp
        return reverse_string_rec(string, n + 1)
    
def factorial_iter(number):
    result = 1

    for i in range(1, number + 1):
        result *= i

    return result

def factorial_rec(number):
    if number == 0:
        return 1
    else:
        return number * factorial_rec(number - 1)

def timeof(func, *args, **kwargs):
    start = timeit.default_timer()
    result = func(*args, **kwargs)
    stop = timeit.default_timer()

    time = stop - start
    print("function: ", func.__name__, 
          ", time: ", format(time, '.10f'), 
          ", result: ", result,
          sep='')

    return result

#####################################################

number = 555
degree = 66

print("\tpow")
timeof(pow_iter, number, degree)
timeof(pow_rec, number, degree)

string = "ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, ya hochy domoi, "

print("\treverse")
timeof(reverse_string_iter, string)
string_list = list(string)
timeof(reverse_string_rec, string_list)

factorial_number = 100

print("\tfactorial")
timeof(factorial_iter, factorial_number)
timeof(factorial_rec, factorial_number)