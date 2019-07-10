package viewModel

type ApiResult struct {
	Code string
	Msg  string
	Data interface{}
}

func Result(code string, msg string, data interface{}) *ApiResult {
	return &ApiResult{code, msg, data}
}
func ResultOK(data interface{}) *ApiResult {
	return &ApiResult{"success", "success", data}
}
func ResultErr(ex interface{}) *ApiResult {
	return &ApiResult{"failed", "failed", ex}
}
