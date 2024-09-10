
# def sort(list_int, key: bool = True):
#     length = len(list_int)
#     for i in range(len(list_int)):
#         for j in range(i):
#             if list_int[i] < list_int[j] and key:
#                 swap(list_int, j, i)
#             elif list_int[i] > list_int[j] and not key:
#                 swap(list_int, j, i)
                

# def swap(list, f_index, s_index):
#     temp = list[f_index]
#     list[f_index] = list[s_index]
#     list[s_index] = temp


def dictionary_counter(string):
    unique_chars_list = list(string)
    unique_chars_list = unique(unique_chars_list)

    dictionary = {}
    for c in unique_chars_list:
        dictionary[c] = count_symbols(string, c)

    return dictionary


def count_symbols(string: str, symbol):
    count = string.count(symbol)
    return count


def unique(items: list) -> list:
    unique_list = []

    for i in items:
        if i not in unique_list:
            unique_list.append(i)

    return unique_list

int_list = [2, 22, 1, 45, 77, 12, 10, 7, 44, 87, 999, 2]
int_list.sort(reverse=True)
print(int_list)
int_list.sort()
print(int_list)

string = "123211aaabgd"
dic = dictionary_counter(string)
print(dic)

char_list = ['f', 'f', 'a', 'c', 'g', 'f', 'r', 'h', 's']
lst = unique(char_list)
print(lst)

# print(count_symbols("123211", '1'))
# dictionary_counter("123211")