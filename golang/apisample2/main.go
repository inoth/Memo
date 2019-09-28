package main

import (
	"apisample/controller/router"
	"apisample/model/db"
	"os"
)

func main() {

	if !db.Instance().InitDb() {
		os.Exit(1)
	}

	r := router.InitRouter()
	r.Run(":8080")
}
