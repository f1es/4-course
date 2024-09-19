import os
import shutil
from pathlib import Path


def make_dir(name: str) -> None:
    os.makedirs(name, exist_ok=True)


def read_file(path: str) -> str:
    with open(path, 'r') as file:
        text = file.read()
        return text


def write_file(path: str = "", text: str = "", file_mode: str = 'w') -> None:
    with open(path, file_mode) as file:
        file.write(text)


def write_from_dir(dir_path: str, file_path: str) -> None:
    dir_files = os.listdir(dir_path)
    for file in dir_files:
        text = read_file(os.path.join(dir_path, file))
        write_file(file_path, "\n" + text, 'a')


def copy_file(path: str) -> None:
    extension = Path(path).suffix
    file_name = Path(path).stem + "_backup" + extension

    lst = path.split('\\')
    lst.pop()
    lst.append(file_name)
    copy_path = '\\'.join(lst)

    shutil.copy(path, copy_path)


def del_file(path: str) -> None:
    os.remove(path)


def rename_file(path: str, new_path: str) -> None:
    os.rename(path, new_path)


# make_dir('project')

file_name = "data.txt"
text = "some text\nsome text"
path = os.path.join(os.getcwd(), "project", file_name)

#write_file(path=path, text=text)

# data = read_file(path)
# print(data)

#copy_file(path)

#del_file(path)

path_list = path.split('\\')
path_list.pop()
path_list.append("data_backup.txt")
backup_path = '\\'.join(path_list)
#rename_file(backup_path, path)

dir_list = path.split('\\')
dir_list.pop()
dir_list.pop()
dir_list.append("content")
dir_path = '\\'.join(dir_list)

write_from_dir(dir_path, path)