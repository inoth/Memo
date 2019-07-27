package controller

import (
	"apiSample/middleware"

	"github.com/gin-gonic/gin"
)

func HttpInit() *gin.Engine {
	r := gin.New()
	r.Use(middleware.Logger, middleware.GlobalPanic)
	user := r.Group("/api/user", middleware.TokenVerification)
	user.GET("", QueryUserList)
	user.GET("/:id", QueryUser)
	return r
}
