package logger

import (
	uuid "github.com/satori/go.uuid"

	"github.com/weekface/mgorus"

	"github.com/sirupsen/logrus"
)

var (
	// lm   *LoggerManager
	// once sync.Once
	// l    *logrus.Logger
	log *logrus.Entry
)

// type LoggerManager struct {
// }

// func Instance() *LoggerManager {
// 	once.Do(func() {
// 		lm = &LoggerManager{}
// 	})
// 	return lm
// }

// func (lm *LoggerManager) InitLog() bool {
// 	l = logrus.New()
// 	hooker, err := mgorus.NewHookerWithAuth("192.168.138.138:27017", "logger", "testapi", "logger", "inoth/*-+")
// 	if err == nil {
// 		l.Hooks.Add(hooker)
// 		return true
// 	}
// 	return false
// }
// func (lm *LoggerManager) GetLog() *logrus.Logger {
// 	return l
// }

// func InitRequest() {
// 	log = Instance().GetLog().WithFields(logrus.Fields{"rid": random()})
// }

func InitLog() {
	hooker, err := mgorus.NewHookerWithAuth("192.168.138.138:27017", "logger", "webapi", "logger", "inoth/*-+")
	if err == nil {
		logrus.AddHook(hooker)
	}
}
func InitRequest() {
	log = logrus.WithFields(logrus.Fields{"rid": random()})
}

func Info(args ...interface{}) {
	log.Info(args)
}
func Infof(format string, args ...interface{}) {
	log.Infof(format, args)
}

func random() string {
	return uuid.NewV4().String()[:8]
}
