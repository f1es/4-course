
def function(key_word: str, path: str):
    with open(path, 'r') as file:
        lines = file.readlines()
    
    for line in lines:
        if key_word in line:
            print(line)


function("key_word", '1.txt')