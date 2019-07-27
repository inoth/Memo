package inosocket

import (
	"net"
)

type HandlerFunc func(net.Conn)
type SendHandlerFunc func(net.Conn, string)

type InoSocket struct {
	Clients       []net.Conn
	Message       chan string
	ClientHandler HandlerFunc
	SendHandler   SendHandlerFunc
	ReadHandler   HandlerFunc
	CloseHandler  HandlerFunc
}

func (s *InoSocket) InitServer() error {
	listen, err := net.Listen("tcp", "localhost:7777")
	if err != nil {
		return err
	}
	for {
		conn, err := listen.Accept()
		if err != nil {
			continue
		}
		s.Clients = append(s.Clients, conn)
		s.ClientHandler(conn)
		go s.ReadHandler(conn)
	}
}

func (s *InoSocket) SendMessage(msg string) {
	for _, conn := range s.Clients {
		s.SendHandler(conn, msg)
	}
}
