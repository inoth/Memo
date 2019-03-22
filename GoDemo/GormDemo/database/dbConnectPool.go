package database

import (
	"sync"

	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/mysql"
)

type DbConnectPool struct {
}

var instance *DbConnectPool
var once sync.Once

var db *gorm.DB
var err_db error

func Instance() *DbConnectPool {
	once.Do(func() {
		instance = &DbConnectPool{}
	})
	return instance
}

func (dcp *DbConnectPool) InitDb() (issucc bool) {
	db, err_db = gorm.Open("mysql", "")
	println(err_db)
	if err_db != nil {
		return false
	}
	return true
}

func (dcp *DbConnectPool) GetMySqlDB() (db_con *gorm.DB) {
	return db
}
