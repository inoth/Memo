package model

import "time"

type UserInfo struct {
	Uid          string `gorm:"primary_key"`
	Uname        string
	Email        string
	Address      string
	Icon         string
	Phone        string
	State        uint
	PresentTitle string
	WebPresent   string
	SelfPresent  string
	CreatedAt    time.Time `gorm:"column:create_time"`
	Work         []Work
}

type Work struct {
	WorkId       uint   `gorm:"AUTO_INCREMENT"`
	Uid          string `gorm:"index"`
	Title        string
	Introduction string
	Path         string
	ImgPath      string
	State        uint
	CreatedAt    time.Time
}

func (UserInfo) TableName() string {
	return "user_info"
}
func (Work) TableName() string {
	return "works"
}
