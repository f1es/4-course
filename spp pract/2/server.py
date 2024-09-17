import socket
import time
import random
import threading


class RefInt:
    def __init__(self, value: int) -> None:
        self.value = value


def number_updater(length: int, ref_int: RefInt, sockets: list, seconds: int = 60) -> None:
    ref_int.value = get_number(length)
    send_messages(sockets, "number updated")
    print(f"number updated now is {ref_int.value}")
    thread = threading.Timer(seconds, number_updater, args=[5, ref_int, sockets, seconds])
    thread.start()


def get_number(length: int) -> int:
    return random.randint(1, length)


def get_sockets(count: int) -> list:
    server_socket = socket.socket(family=socket.AF_INET, type=socket.SOCK_STREAM)
    server_socket.bind(('localhost', 8080))
    server_socket.listen(count)

    sockets = []
    for i in range(count):
        client_socket, client_address = server_socket.accept()
        sockets.append(client_socket)
    return sockets


def close_sockets(sockets: list) -> None:
    for socket in sockets:
        socket.close()


def recv_message(socket: socket, bytes_count: int = 1024) -> str:
    data = socket.recv(bytes_count)
    message = data.decode()
    return message


def send_message(socket: socket, message: str) -> None:
    data = message.encode()
    socket.send(data)


def send_messages(sockets: list, message: str) -> None:
    for socket in sockets:
        send_message(socket, message)


def guess(sockets: list, ref_int: RefInt) -> None:
    for socket in sockets:
        thread = threading.Thread(target=guess_thread, args=[socket, ref_int])
        thread.start()

    print("number wosnt guessed :(")


def guess_thread(socket: socket, ref_int: RefInt):
    while True:
        msg = recv_message(socket)
        try:
            if compare(msg, ref_int.value):
                send_message(socket, "you guess number")
                print(f"number guessed, number is {ref_int.value}")
            else:
                send_message(socket, f"nope, is {ref_int.value}")
        except:
            send_message(socket, "incorrect input")
    

def compare(message: str, number: int) -> bool:
    if int(message) == number:
        return True
    else:
        return False


sockets = get_sockets(2)
ref_int = RefInt(2)
number_updater(length=10, ref_int=ref_int, sockets=sockets, seconds=15)
guess(sockets, ref_int)

while True:
    pass
    #guess(sockets, val.value)

#close_sockets(sockets)

