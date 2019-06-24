package main

import (
	"net/http"
	"strings"

	"github.com/gin-gonic/gin"

	log "inoProject/logdemo/util/logger"
)

func main() {
	// println("start....")
	// log := logrus.New()
	// println("client....")
	// hooker, err := mgorus.NewHookerWithAuth("192.168.138.138:27017", "logger", "collection", "logger", "inoth/*-+")
	// if err == nil {
	// 	log.Hooks.Add(hooker)
	// } else {
	// 	println(err)
	// }
	// println("....")
	// // log = log.WithFields(logrus.Fields{"inoth": "123123"})
	// log.Info("hello world")
	// log.WithFields(logrus.Fields{
	// 	"name": "zhangsan",
	// 	"age":  28,
	// }).Error("Hello world!")

	r := gin.New()

	// if issucc := log.InitLogger(); !issucc {
	// 	os.Exit(1)
	// }

	log.InitLog()
	// log.Instance().InitLog()

	r.Use(Logger())

	test := r.Group("/api/user", Test())

	test.GET("/", func(c *gin.Context) {
		log.Info("123123123")
	})
	r.POST("/api/post", func(c *gin.Context) {
		c.JSON(http.StatusOK, gin.H{
			"code": "200"})
	})
	r.Run(":7777")
}

func Logger() gin.HandlerFunc {
	return func(c *gin.Context) {
		log.InitRequest()
		log.Infof("[%s] - %s", c.Request.Method, c.Request.RequestURI)
		if !strings.EqualFold(c.Request.Method, "GET") {
			// do something
		}
		c.Next()
		log.Infof("result: [%d]", c.Writer.Status())
	}
}

func Test() gin.HandlerFunc {
	return func(c *gin.Context) {
		log.Info("1?????")
		c.Next()
		log.Info("2?????")
	}
}
