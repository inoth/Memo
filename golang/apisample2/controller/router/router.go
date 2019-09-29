package router

import (
	"apisample/controller"
	ex "apisample/controller/exceptionHandler"
	mid "apisample/controller/middleware"
	"apisample/util"
	"strings"

	"github.com/gin-gonic/gin"
	"github.com/sirupsen/logrus"
)

func InitRouter() *gin.Engine {
	r := gin.New()

	// 全局异常处理使用第一个中间件
	// r.Use(mid.ExceptionHandle)

	r.Use(mid.LoggerInit)

	api := r.Group("/api")
	api.GET("/user", wrapper(controller.QueryUserList))
	api.GET("/error/:id", wrapper(controller.SelfError))
	return r
}

// 无法捕获中间件的异常
func wrapper(handler gin.HandlerFunc) gin.HandlerFunc {

	return func(c *gin.Context) {
		// 截取报文输出日志
		cp := c.Copy()
		go func() {
			logrus.Info("协程输出：" + cp.Request.URL.Path)
			logrus.Info("协程输出：" + cp.Request.URL.RawQuery)

			if !strings.EqualFold(cp.Request.Method, "GET") {
				// cp.Request.Body.Read()
			}

		}()

		defer func() {
			if err := recover(); err != nil {
				// 捕获错误
				switch e := err.(type) {
				case *ex.ParamErrException:
					logrus.Error(e.Msg)
					c.JSON(500, util.Result(util.FAILED, e.Msg, nil))
				case *ex.DataNullException:
					logrus.Error(e.Msg)
					c.JSON(500, util.Result(util.FAILED, e.Msg, nil))
				default:
					c.JSON(500, util.Result(util.FAILED, "unknown exception.", nil))
				}
			}
		}()

		handler(c)
	}
}
