package middleware

import "github.com/gin-gonic/gin"

func TokenVerification(c *gin.Context) {
	// ここで何がやってみよう
	c.Next()
}
