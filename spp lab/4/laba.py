import numpy

def sort(list_int, key: bool = True):
    length = len(list_int)
    for i in range(len(list_int)):
        for j in range(i):
            if list_int[i] < list_int[j] and key:
                swap(list_int, j, i)
            elif list_int[i] > list_int[j] and not key:
                swap(list_int, j, i)
                
def swap(list, f_index, s_index):
    temp = list[f_index]
    list[f_index] = list[s_index]
    list[s_index] = temp

def dictionary_counter(string):
    string_list = list(string)
    string_list = string_list.unique()
    print(string_list)
def count_symbols(string: str, symbol):
    count = string.count(symbol)
    return count

numbers = {2, 22, 1, 45, 77, 12, 10, 7, 44, 87, 999}
some_list = list(numbers)
sort(some_list)
print(some_list)

print(count_symbols("123211", '1'))
dictionary_counter("123211")