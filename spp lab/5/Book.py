
class Book:
    _count = 0
    def __init__(self):
        Book._count += 1


for i in range(8):
    book = Book()
print(Book._count)
