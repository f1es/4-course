import socket
import os
import threading


def cls():
    os.system('cls' if os.name=='nt' else 'clear')


def connect(server_address) -> socket:
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect(server_address)
    print("connected")
    return client_socket


def recv_message(socket: socket, bytes_count: int = 1024) -> str:
    data = socket.recv(bytes_count)
    message = data.decode()
    return message


def recv_message_cycle(socket: socket, bytes_count: int = 1024) -> str:
    while True:
        data = socket.recv(bytes_count)
        message = data.decode()
        print(message)


def send_message(socket: socket, message: str) -> None:
    data = message.encode()
    socket.send(data)


server_address = ('localhost', 8080)
client_socket = connect(server_address)


thread = threading.Thread(target=recv_message_cycle, args=[client_socket])
thread.start()

message = ""
while message != "!":
    print("Input number:", end=' ')
    message = input()
    send_message(client_socket, message)

client_socket.close()