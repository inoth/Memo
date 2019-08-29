package com.apisample.inoth.middleware;

import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseBody;

import javax.servlet.http.HttpServletRequest;

@ControllerAdvice
public class GlobalExceptionHandler {

    @ExceptionHandler(Exception.class)
    @ResponseBody
    public String ErrorHandler(HttpServletRequest request, Exception e) {
//        log.info("系统异常： " + e.getMessage());
//        log.error(request.getRequestURL().toString(), e);
        // 记录异常日志
        return "系统繁忙";
    }
}
