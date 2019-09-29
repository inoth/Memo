package middleware

import (
	ex "apisample/controller/exceptionHandler"

	"github.com/gin-gonic/gin"
	"github.com/sirupsen/logrus"
)

func LoggerInit(c *gin.Context) {
	logrus.Info("这里是日志中间件")
	panic(ex.DataNilException("qweqwe"))
	c.Next()
}
