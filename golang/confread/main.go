package main

import (
	"confread/conf"
	"fmt"
	"io/ioutil"

	"gopkg.in/yaml.v2"
)

type Cache struct {
	Nodes string `yaml:"nodes"`
}
type Db struct {
	User string `yaml:"user"`
	Pwd  string `yaml:"pwd"`
	Host string `yaml:"host"`
	Port string `yaml:"port"`
	Name string `yaml:"name"`
}

type Conf struct {
	Cache Cache `yaml:"Cache"`
	Db    Db    `yaml:"Db"`
	// Cache struct {
	// 	Nodes string `yaml:"nodes"`
	// } `yaml:"Cache"`
	// Db struct {
	// 	User string `yaml:"user"`
	// 	Pwd  string `yaml:"pwd"`
	// 	Host string `yaml:"host"`
	// 	Port string `yaml:"port"`
	// 	Name string `yaml:"name"`
	// } `yaml:"Db"`
}

func (c *Conf) getConf() {
	yamlFile, err := ioutil.ReadFile("conf.yaml")
	if err != nil {
		println(err)
	}
	println(string(yamlFile))
	err = yaml.Unmarshal(yamlFile, c)
	if err != nil {
		println(err)
	}
}

func main() {
	// var c Conf
	// c.getConf()
	// println(c.Cache.Nodes)
	// println(c.Db.User)
	// println(c.Db.Pwd)
	// u1 := uuid.NewV4().String()
	// println(u1[:8])
	// fmt.Printf("UUIDv4: %s\n", u1)
	// if conf.Instance().LoadConf() != nil {
	// 	panic("load conf failed")
	// 	os.Exit(1)
	// }
	fmt.Printf("%p\n", conf.Instance())
	fmt.Printf("%p\n", conf.Instance())
	fmt.Printf("%p\n", conf.Instance())
	println(conf.Instance().Cache.Nodes)
}
