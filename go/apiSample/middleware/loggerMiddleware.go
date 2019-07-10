package middleware

import (
	"apiSample/util/logger"

	"github.com/gin-gonic/gin"
)

func Logger(c *gin.Context) {
	logger.InitRequest()
	logger.Infof("api request: %s", c.Request.RequestURI)
	c.Next()
}
