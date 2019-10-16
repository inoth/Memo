package main

import (
	"apisample/controller/router"
	"apisample/model/db"
	"apisample/util"
	"os"
)

func main() {

	if !db.Instance().InitDb() {
		os.Exit(1)
	}

	util.InitLog()

	r := router.InitRouter()

	r.Run(":8080")
}
