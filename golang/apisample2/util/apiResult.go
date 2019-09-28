package util

const (
	SUCCESS = 200
	FAILED  = 500
)

type ApiResult struct {
	Code int         `json:"code"`
	Msg  string      `json:"msg"`
	Data interface{} `json:"data"`
}

func Result(code int, msg string, data interface{}) *ApiResult {
	return &ApiResult{
		Code: code,
		Msg:  msg,
		Data: data,
	}
}
