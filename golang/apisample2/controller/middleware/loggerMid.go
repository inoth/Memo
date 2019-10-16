package middleware

import (
	"strings"

	"github.com/gin-gonic/gin"
	"github.com/sirupsen/logrus"
)

func LoggerInit(c *gin.Context) {
	cp := c.Copy()
	go func() {
		defer func() {
			if err := recover(); err != nil {
				logrus.Errorf("%v", err)
			}
		}()

		logrus.Info("协程输出：" + cp.Request.URL.Path)
		logrus.Info("协程输出：" + cp.Request.URL.RawQuery)
		if !strings.EqualFold(cp.Request.Method, "GET") {
			data, _ := cp.GetRawData()
			logrus.Info(string(data))
		}
		panic("参数日志输出错误")
	}()
	c.Next()
}
