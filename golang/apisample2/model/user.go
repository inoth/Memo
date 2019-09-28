package model

type User struct {
	Id   uint
	Name string
}

func (m *User) TableName() string {
	return "user"
}
