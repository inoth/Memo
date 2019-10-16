package controller

import (
	ex "apisample/controller/exceptionHandler"
	"apisample/model"
	"apisample/model/db"
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/sirupsen/logrus"
)

func QueryUserList(c *gin.Context) {

	// c.JSON(http.StatusOK, gin.H{"name": "inoth"})

	var user []model.User

	dc := db.Instance()
	dc.Db.Find(&user)

	c.JSON(http.StatusOK, user)

}

func SelfError(c *gin.Context) {
	logrus.Info("控制器输出")
	logrus.Info(c.PostForm("id"))
	panic(ex.ParamErrorException("参数错误"))
	panic(ex.ParamErrorException("参数错误2"))
}
