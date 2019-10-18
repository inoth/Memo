package main

import (
	"context"
	"log"
	"net"

	pb "github.com/inoth/golib/message"

	"google.golang.org/grpc"
)

const (
	port = ":50051"
)

type demoserver struct {
	pb.UnimplementedDemoServiceServer
}

func (s *demoserver) SayHi(ctx context.Context, req *pb.Request) (*pb.Result, error) {
	return &pb.Result{Msg: req.Msg}, nil
}

func main() {
	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	pb.RegisterDemoServiceServer(s, &demoserver{})
	if err := s.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
