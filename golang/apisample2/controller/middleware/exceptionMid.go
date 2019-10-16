package middleware

import (
	ex "apisample/controller/exceptionHandler"
	"apisample/util"

	"github.com/gin-gonic/gin"
	"github.com/sirupsen/logrus"
)

// 仅作于捕获控制器异常，中间件异常捕获会影响到控制器异常捕获？
func ExceptionHandle(c *gin.Context) {
	defer func() {
		if err := recover(); err != nil {
			// 捕获错误
			switch e := err.(type) {
			case *ex.ParamErrException:
				logrus.Error(e.Msg)
				c.JSON(200, util.Result(util.FAILED, e.Msg, nil))
			case *ex.DataNullException:
				logrus.Error(e.Msg)
				c.JSON(200, util.Result(util.FAILED, e.Msg, nil))
			default:
				c.JSON(500, util.Result(util.FAILED, "unknown exception.", nil))
			}
		}
	}()
	c.Next()
}
