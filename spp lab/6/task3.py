def sum_from_file(path: str):
    with open(path, 'r') as file:
        text = file.read()
    file.close()

    numbers = text.split(' ')
    sum = 0
    for i in numbers:
        sum += int(i)
    
    return sum

a = sum_from_file('3.txt')
print(a)