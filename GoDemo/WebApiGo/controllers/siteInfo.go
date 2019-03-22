package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

func ApiTest(c *gin.Context) {
	id := c.Param("id")
	c.JSON(http.StatusOK, gin.H{"mssage": id})
}

func QuerySiteInfoById(c *gin.Context) {
	id := c.Query("uid")
	c.JSON(http.StatusOK, gin.H{"user": id})
}
