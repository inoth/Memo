package db

import (
	"sync"

	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/mysql"
)

type DbConnect struct {
	Db  *gorm.DB
	Err error
}

var (
	once     sync.Once
	instance *DbConnect
	// db       *gorm.DB
	// err      error
)

func Instance() *DbConnect {
	once.Do(func() {
		instance = &DbConnect{}
	})
	return instance
}

func (dbc *DbConnect) InitDb() bool {
	dbc.Db, dbc.Err = gorm.Open("mysql", "inoth:inoth123@(192.168.146.128:3306)/inoth_local?charset=utf8")
	if dbc.Err != nil {
		dbc.Db.Close()
		return false
	}
	dbc.Db.DB().SetMaxIdleConns(10)
	dbc.Db.DB().SetMaxOpenConns(20)
	dbc.Db.LogMode(true)
	return true
}

// func (dbc *DbConnect) GetClient() *gorm.DB {
// 	return dbc.Db
// }
