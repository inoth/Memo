package exceptionHandler

import (
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

func ParamErrorException(msg string) *ParamErrException {
	return &ParamErrException{
		Msg: msg,
	}
}
