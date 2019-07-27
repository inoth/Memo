package config

import (
	"fmt"
	"io/ioutil"
	"os"
	"sync"

	"gopkg.in/yaml.v2"
)

type name struct {
}

type Config struct {
	Cache struct {
		Nodes string `yaml:"nodes"`
	} `yaml:"Cache"`
	DB struct {
		MySql struct {
			Connect string `yaml:"Connect"`
		} `yaml:"MySql"`
		Mongo struct {
			DbName  string `yaml:"DbName"`
			User    string `yaml:"User"`
			Pwd     string `yaml:"Pwd"`
			Host    string `yaml:"Host"`
			TabName string `yaml:"TabName"`
		} `yaml:"Mongo"`
	} `yaml:"DB"`
	ServerPort string `yaml:"ServerPort"`
}

var (
	once sync.Once
	conf *Config
)

func Instance() *Config {
	once.Do(func() {
		conf = &Config{}
		if err := conf.LoadConf(); err != nil {
			fmt.Printf("panic recover: %v", err)
			os.Exit(1)
		}
	})
	return conf
}
func (c *Config) LoadConf() error {
	yamlFile, err := ioutil.ReadFile("conf.yaml")
	if err != nil {
		return err
	}
	err = yaml.Unmarshal(yamlFile, c)
	if err != nil {
		return err
	}
	return nil
}
