package routers

import (
	"InothProject/WebApiGo/controllers"

	"github.com/gin-gonic/gin"
)

func InitRouter() *gin.Engine {
	r := gin.Default()
	r.GET("/apitest/:id", controllers.ApiTest)
	r.GET("/api/query/siteinfo", controllers.QuerySiteInfoById)
	return r
}
