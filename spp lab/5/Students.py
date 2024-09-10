import random

class Student:
    def __init__(self, name):
        self.__name = name
        self.__grades = []
        
    def add_grade(self, grade: int):
        self.__grades.append(grade)

    def avg_grade(self):
        sum = 0
        ct = self.__grades.__len__()
        for grade in self.__grades:
            sum += grade
        return sum / ct

    def add_some_grades(self):
        for i in range(5):
            self.add_grade(random.randrange(4, 10))

    def print_grades(self):
        print("grades of", self.__name, ":", self.__grades)

    def print_info(self):
        print("student:", self.__name, "avg grade:", self.avg_grade())


class Students:
    def __init__(self) -> None:
        self.__students = []
        pass

    def add_sudent(self, student: Student):
        self.__students.append(student)

    def avg_grade(self):
        sum = 0
        count = self.__students.__len__()
        for student in self.__students:
            sum += student.avg_grade()
        return sum / count

st1 = Student("Zybenko Mihail Petrovich")
st1.add_some_grades()
st1.print_grades()
st1.print_info()
print()

st2 = Student("Ivanov Ivanov Ivanov")
st2.add_some_grades()
st2.print_grades()
st2.print_info()
print()

st3 = Student("Lanus Elizaveta Dmitrievna")
st3.add_some_grades()
st3.print_grades()
st3.print_info()
print()

students = Students()
students.add_sudent(st1)
students.add_sudent(st2)
students.add_sudent(st3)
print("avg grade of all sdudents:", students.avg_grade())