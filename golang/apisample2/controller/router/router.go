package router

import (
	"apisample/controller"
	mid "apisample/controller/middleware"

	"github.com/gin-gonic/gin"
)

func InitRouter() *gin.Engine {
	r := gin.New()

	// 全局异常处理使用第一个中间件
	r.Use(mid.LoggerInit)

	r.Use(mid.ExceptionHandle)

	api := r.Group("/api")
	api.GET("/user", controller.QueryUserList)
	api.POST("/error", controller.SelfError)
	return r
}
