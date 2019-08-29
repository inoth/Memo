package com.apisample.inoth.middleware;

import org.springframework.stereotype.Component;
import org.springframework.web.servlet.HandlerInterceptor;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.util.UUID;

@Component
public class LoggerInterceptor implements HandlerInterceptor {
    @Override
    public boolean preHandle(HttpServletRequest request, HttpServletResponse response, Object obj) throws Exception {
        Thread.currentThread().setName(UUID.randomUUID().toString().substring(0, 8));

        // 使用中间件统一记录请求日志
        if (request.getMethod().equalsIgnoreCase("post")) {

        }

        return true;
    }
}
