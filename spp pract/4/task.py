import os
import shutil

def make_dir(name: str) -> None:
    os.makedirs(name, exist_ok=True)


def write_file(path: str = "", text: str = "") -> None:
    with open(path, 'w') as file:
        file.write(text)


def read_file(path: str) -> str:
    with open(path, 'r') as file:
        text = file.read()
        return text


def copy_file(path: str) -> None:
    file_name = os.path.basename(path)
    
    shutil.copy(path, copy_path)

# make_dir('project')
file_name = "data.txt"
text = "some text\nsome text"
path = os.path.join(os.getcwd(), "project", file_name)
#write_file(path=path, text=text)

# data = read_file(path)
# print(data)

copy_file(path)