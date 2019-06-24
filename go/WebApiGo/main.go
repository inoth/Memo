package main

import (
	"InothProject/WebApiGo/routers"
)

func main() {
	r := routers.InitRouter()
	r.Run(":9999")
}
