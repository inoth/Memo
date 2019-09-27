package main

import (
	"strconv"

	"github.com/gin-gonic/gin"
	_ "github.com/go-sql-driver/mysql"
	"github.com/jinzhu/gorm"
)

var db *gorm.DB

func initdb() {
	var err error
	db, err = gorm.Open("mysql", "")
	if err != nil {
		panic(err)
	}
	db.DB().SetMaxIdleConns(10)
	db.DB().SetMaxOpenConns(20)
	// db.LogMode(true)
}

type AccessLog struct {
	Name     string
	Title    string
	Path     string
	Url      string
	Hostname string
	Time     string
}

type Total struct {
	Count uint
}

func main() {

	initdb()

	r := gin.New()
	// 添加中间件
	r.Use(globalPanic)

	// 路由分组
	r.GET("/aclog", queryList)
	r.Run(":9978")
}

func globalPanic(c *gin.Context) {
	defer func() {
		if pr := recover(); pr != nil {
			// 全局错误处理
			c.JSON(500, gin.H{"code": 500, "msg": "system error."})
		}
	}()
	c.Next()
}

func queryList(c *gin.Context) {
	index := c.Query("index")
	size := c.Query("size")

	i, _ := strconv.Atoi(index)
	s, _ := strconv.Atoi(size)

	var aclog []AccessLog
	var total Total

	db.Table("accesslog as t").Select("count(1) as `count`").Where("t.`uid` <> 0").Find(&total)

	db.Table("accesslog as t").Select("u.`name`, t.`path`, t.`title`, t.`url`, t.`hostname`, FROM_UNIXTIME(t.`timestamp`,'%Y-%m-%d %H:%i:%S') as `time`").
		Joins("left join `users` as u on t.`uid` = u.`uid`").Where("t.`uid` <> 0").Order("t.`timestamp` desc").Limit(s).Offset(s * (i - 1)).Find(&aclog)

	c.JSON(200, gin.H{"code": 200, "msg": "success", "data": aclog, "total": total.Count})
}
