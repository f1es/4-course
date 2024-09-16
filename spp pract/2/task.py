import socket
server_socket = socket.socket(family=socket.AF_INET, type=socket.SOCK_STREAM)
server_socket.bind(('localhost', 8080))
server_socket.listen(3)

client_socket, client_address = server_socket.accept()
print(f"connected with {client_address}")