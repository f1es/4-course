
def form(number):
    return format(float(number), '.2f')

a = int(input())
b = int(input())

print("sum:", a + b)
print("razn:", a - b)
print("mult:", a * b)
print("div:", form(a / b))
print("div bez ost:", a // b)
print("ostatok:", a % b)
print("stepen:", a ** b)

print(a & b)
print(a | b)
print(a ^ b)
# -(n + 1)
print(~a)
print(~b)
# / 2^n
print(a >> 1)
# * 2^n
print(b << 1)

