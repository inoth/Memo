package exceptionHandler

// 委托类型定义
// type HandlerFunc func(c *gin.Context) error

type ParamErrException struct {
	Msg string
}
type DataNullException struct {
	Msg string
}

// 继承 error 接口
func (ex *ParamErrException) Error() string {
	return ex.Msg
}
func (ex *DataNullException) Error() string {
	return ex.Msg
}

func ParamErrorException(msg string) *ParamErrException {
	return &ParamErrException{
		Msg: msg,
	}
}

func DataNilException(msg string) *DataNullException {
	return &DataNullException{
		Msg: msg,
	}
}
