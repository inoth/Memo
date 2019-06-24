package main

import (
	"InothProject/GoDemo/database"
	"os"
)

// type MainDbAccess interface {
// 	Query() string
// 	Update() uint
// }
// type UserInfoAccess interface {
// 	MainDbAccess
// 	Delete() uint
// }
// type PageInfoAccess interface {
// 	MainDbAccess
// }

// type UserInfo struct {
// 	uid   string
// 	uname string
// }
// type PageInfo struct {
// 	pageId   uint
// 	pageName string
// }

// func (p *PageInfo) Query() string {
// 	return p.pageName
// }
// func (p *PageInfo) Update() uint {
// 	return 1
// }

// func (u *UserInfo) Query() string {
// 	return u.uid + u.uname
// }
// func (u *UserInfo) Update() uint {
// 	return 1
// }
// func (u *UserInfo) Delete() uint {
// 	return 2
// }

func main() {
	// var user UserInfoAccess
	// user = &UserInfo{"u1081", "inoth"}
	// println(user.Query())

	// var page MainDbAccess
	// page = &PageInfo{233, "始めるよう"}
	// println(page.Query())
	// issucc := database.Instance().InitDb()
	if issucc := database.Instance().InitDb(); !issucc {
		println("db error")
		os.Exit(1)
	}

	user := database.QueryById("U1081")
	println(user.Uid)
	println(user.Uname)
	users := *database.QueryAll()
	for i := 0; i < len(users); i++ {
		println(users[i].Uid)
		println(users[i].Uname)
	}
}
