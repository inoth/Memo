package database

import (
	"InothProject/GoDemo/model"
)

func QueryById(uid string) *model.UserInfo {
	db := Instance().GetMySqlDB()
	user := &model.UserInfo{}
	db.Where(&model.UserInfo{Uid: uid}).First(user)
	return user
}
func QueryAll() *[]model.UserInfo {
	db := Instance().GetMySqlDB()
	users := &[]model.UserInfo{}
	db.Find(users)
	return users
}
