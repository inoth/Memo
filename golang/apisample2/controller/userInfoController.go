package controller

import (
	ex "apisample/controller/exceptionHandler"
	"apisample/model"
	"apisample/model/db"
	"net/http"

	"github.com/gin-gonic/gin"
)

func QueryUserList(c *gin.Context) error {

	// c.JSON(http.StatusOK, gin.H{"name": "inoth"})

	var user []model.User

	dc := db.Instance()
	dc.Db.Find(&user)

	c.JSON(http.StatusOK, user)

	return nil
}

func SelfError(c *gin.Context) error {
	return ex.ParamErrorException("参数错误")
}
