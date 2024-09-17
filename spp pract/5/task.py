import requests
import os
import threading
import datetime

def print_response(url: str) -> None:
    os.system('cls')
    print("at", datetime.datetime.now())
    #response = requests.get(url)
    #print(response.text)
    print("im response")

def print_response_thread(url: str, seconds: int = 15) -> threading.Timer:
    print_response(url)
    thread = threading.Timer(seconds, print_response_thread, args=[url, seconds])
    thread.start()
    return thread

url = "https://jsonplaceholder.typicode.com/todos/1"
th = print_response_thread(url)
stop = input()
if stop != '':
    th.cancel()

