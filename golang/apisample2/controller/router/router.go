package router

import (
	"apisample/controller"
	ex "apisample/controller/exceptionHandler"

	"github.com/gin-gonic/gin"
)

// 定义一个委托

func InitRouter() *gin.Engine {
	r := gin.New()

	api := r.Group("/api")
	api.GET("/user", ex.Wrapper(controller.QueryUserList))
	api.GET("/error", ex.Wrapper(controller.SelfError))
	return r
}
