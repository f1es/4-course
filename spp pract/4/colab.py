from google.colab import files
import os


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
        try:
          text = read_file(os.path.join(dir_path, file))
          write_file(file_path, "\n" + text, 'a')
          print(f"write from file {file}")
        except:
          print(f"can't write from file {file}")
          pass

file_name = "data.txt"
path = os.path.join(os.getcwd(), "project", file_name)

dir_path = os.getcwd() + "/content"

write_from_dir(dir_path, path)

files.download(path)
