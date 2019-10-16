package util

import (
	"os"

	lumberjack "gopkg.in/natefinch/lumberjack.v2"

	"github.com/sirupsen/logrus"
)

// var log *logrus.Entry

func InitLog() {
	logrus.SetFormatter(&logrus.TextFormatter{})
	logrus.SetReportCaller(true)
	logrus.SetOutput(os.Stdout)
	logrus.SetOutput(&lumberjack.Logger{
		Filename:   "./log/log.log",
		MaxSize:    10,
		MaxBackups: 1024,
		MaxAge:     30,
		Compress:   true,
	})
}
