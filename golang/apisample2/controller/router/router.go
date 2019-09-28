package router

import (
	"apisample/controller"
	ex "apisample/controller/exceptionHandler"
	"apisample/util"
	"strings"

	"github.com/gin-gonic/gin"
)

func InitRouter() *gin.Engine {
	r := gin.New()

	api := r.Group("/api")
	api.GET("/user", Wrapper(controller.QueryUserList))
	api.GET("/error/:id", Wrapper(controller.SelfError))
	return r
}

func Wrapper(handler ex.HandlerFunc) func(c *gin.Context) {
	return func(c *gin.Context) {

		// 截取报文输出日志
		cp := c.Copy()
		go func() {
			println(cp.Request.URL.Path)
			println("协程输出：" + cp.Request.URL.RawQuery)

			if !strings.EqualFold(cp.Request.Method, "GET") {
				// cp.Request.Body.Read()
			}

		}()

		if err := handler(c); err != nil {
			// 捕获错误
			switch ex := err.(type) {
			case *ex.ParamErrException:
				c.JSON(500, util.Result(util.FAILED, ex.Msg, nil))
			default:
				c.JSON(500, util.Result(util.FAILED, "unknown exception.", nil))
			}
		}
	}
}
