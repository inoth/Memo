package util

import uuid "github.com/satori/go.uuid"

func GenerateID() string {
	return uuid.NewV4().String()[:8]
}
