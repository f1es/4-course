text = "Iliya kashuhenok vityalievich-16.16.2016"

print("count: ")
count = int(input())
print("symbol: ")
symbol = input()

array = text.split("-")
left_text = array[0].ljust(count, symbol)
centred_text = array[1].center(count, symbol)
right_text = str(type(text)).rjust(count, symbol)
print(array)

print(left_text)
print(centred_text)
print(right_text)