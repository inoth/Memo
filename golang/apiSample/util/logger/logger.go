package logger

import (
	"apiSample/util/config"

	uuid "github.com/satori/go.uuid"
	"github.com/sirupsen/logrus"
	"github.com/weekface/mgorus"
)

var log *logrus.Entry

func InitLog() {
	mongoConf := config.Instance().DB.Mongo
	hooker, err := mgorus.NewHookerWithAuth(mongoConf.Host, mongoConf.DbName, mongoConf.TabName, mongoConf.User, mongoConf.Pwd)
	if err == nil {
		logrus.AddHook(hooker)
	}
}
func InitRequest() {
	log = logrus.WithField("rid", uuid.NewV4().String()[:8])
}

func Info(args ...interface{}) {
	log.Info(args)
}
func Infof(format string, args ...interface{}) {
	log.Infof(format, args)
}
func Warn(args ...interface{}) {
	log.Warn(args)
}
func Warnf(format string, args ...interface{}) {
	log.Warnf(format, args)
}
func Error(args ...interface{}) {
	log.Error(args)
}
func Errorf(format string, args ...interface{}) {
	log.Errorf(format, args)
}
func Fatal(args ...interface{}) {
	log.Fatal(args)
}
func Fatalf(format string, args ...interface{}) {
	log.Fatalf(format, args)
}
func Panic(args ...interface{}) {
	log.Panic(args)
}
func Panicf(format string, args ...interface{}) {
	log.Panicf(format, args)
}
