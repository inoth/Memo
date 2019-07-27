package conf

import (
	"io/ioutil"
	"sync"

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
}

var (
	once sync.Once
	conf *Conf
)

func Instance() *Conf {
	once.Do(func() {
		conf = &Conf{}
		conf.LoadConf()
	})
	return conf
}
func (c *Conf) LoadConf() {
	yamlFile, err := ioutil.ReadFile("conf.yaml")
	if err != nil {
		panic(err)
	}
	println(string(yamlFile))
	err = yaml.Unmarshal(yamlFile, c)
	if err != nil {
		panic(err)
	}
}
