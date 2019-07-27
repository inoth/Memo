package middleware

import (
	"apiSample/model/viewModel"
	"apiSample/util/logger"
	"net/http"

	"github.com/gin-gonic/gin"
)

func GlobalPanic(c *gin.Context) {
	defer func() {
		if pr := recover(); pr != nil {
			logger.Errorf("panic recover: %v", pr)
			c.JSON(http.StatusOK, viewModel.ResultErr(pr))
		}
	}()
	c.Next()
}
