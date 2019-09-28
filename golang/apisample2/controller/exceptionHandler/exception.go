package exceptionHandler

import (
	"apisample/util"

	"github.com/gin-gonic/gin"
)

// 委托类型定义
type HandlerFunc func(c *gin.Context) error

type ParamErrException struct {
	Msg string
}

// 继承 error 接口
func (ex *ParamErrException) Error() string {
	return ex.Msg
}

func Wrapper(handler HandlerFunc) func(c *gin.Context) {
	return func(c *gin.Context) {
		if err := handler(c); err != nil {
			// 捕获错误
			switch ex := err.(type) {
			case *ParamErrException:
				print(ex.Msg)
				c.JSON(500, util.Result(util.FAILED, ex.Msg, nil))
			default:
				c.JSON(500, util.Result(util.FAILED, "unknown exception.", nil))
			}
		}
	}
}

func ParamErrorException(msg string) *ParamErrException {
	return &ParamErrException{
		Msg: msg,
	}
}
