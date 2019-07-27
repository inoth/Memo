package main

import (
	"apiSample/controller"
	"apiSample/util/config"
	"apiSample/util/logger"
)

func main() {
	r := controller.HttpInit()
	logger.InitLog()
	r.Run(config.Instance().ServerPort)
}
