package main

import (
	"inoProject/socketserver/inosocket"
	"net"
	"os"
)

// var clients = make([]*net.Conn, 0)

func main() {
	// listen, err := net.Listen("tcp", "localhost:7777")
	// if err != nil {
	// 	println("system error!")
	// 	os.Exit(1)
	// }
	// for {
	// 	conn, err := listen.Accept()
	// 	if err != nil {
	// 		continue
	// 	}
	// 	clients = append(clients, &conn)

	// 	conn.Write([]byte("ようこそ、我が世界へ"))
	// 	go func() {
	// 		buffer := make([]byte, 1024)
	// 		for {
	// 			if n, err := conn.Read(buffer); err == nil && n > 0 {
	// 				print(string(buffer[:n]))
	// 			}
	// 		}
	// 	}()
	// }
	socket := &inosocket.InoSocket{
		Clients:       make([]net.Conn, 0),
		Message:       make(chan string),
		ClientHandler: client,
		SendHandler:   send,
		ReadHandler:   read,
		CloseHandler:  close}
	if err := socket.InitServer(); err != nil {
		println("system error")
		os.Exit(1)
	}
	socket.SendMessage("123123123")
}

func client(conn net.Conn) {
	conn.Write([]byte("ようこそ、我が世界へ"))
}
func send(conn net.Conn, msg string) {
	conn.Write([]byte(msg))
}
func read(conn net.Conn) {
	buffer := make([]byte, 1024)
	for {
		if n, err := conn.Read(buffer); err == nil && n > 0 {
			print(string(buffer[:n]))
		}
	}
}
func close(conn net.Conn) {

}
