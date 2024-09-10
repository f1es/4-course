
class Circle:
    def __init__(self, radius):
        self.__radius = radius

    def calc_perimetr(self):
        return 2 * 3.14 * self.__radius
    
    def calc_square(self):
        return 3.14 * pow(self.__radius, 2)
    
    def get_radius(self):
        return self.__radius
    
    
circle = Circle(3)
print(circle.calc_perimetr())
print(circle.calc_square())
print(circle.get_radius())