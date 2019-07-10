package controller

import (
	"apiSample/model/viewModel"
	"net/http"

	"github.com/gin-gonic/gin"
)

func QueryUserList(c *gin.Context) {
	// panic("this is error")
	c.JSON(http.StatusOK, viewModel.ResultOK(nil))
}

func QueryUser(c *gin.Context) {
	id := c.Param("id")
	c.JSON(http.StatusOK, viewModel.Result("success", "ok", id))
}
