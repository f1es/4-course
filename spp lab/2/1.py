

def function_on_interval(min: int, max: int) -> float:
    result = 0
    for i in range(min, max):
        result = function(i)
        print(result)
    return result


def function(x: int) -> float:
    if x < -2:
        return 2 / x + 2
    if x >= -2 and x <= 2:
        return 2
    if x > 2:
        return 1 / 2 * x
    

while True:
    text = input()
    if text == "stop":
        break
    try:
        interval = [int(n) for n in text.split(' ')]
        result = function_on_interval(interval[0], interval[1])
        print(result)
    except:
        pass