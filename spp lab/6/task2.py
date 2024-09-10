
def replace_from_file(word : str, new_word: str, path: str):
    with open(path, 'r') as file:
        text = file.read()
    file.close()

    print(text)
    print()

    text = text.replace(word, new_word)
    print(text)

path = '2.txt'
replace_from_file("little", "much", path)