package com.apisample.inoth.config;

import com.apisample.inoth.middleware.LoggerInterceptor;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

import javax.annotation.Resource;

public class WebConfig implements WebMvcConfigurer {
    @Resource
    private LoggerInterceptor loggerInterceptor;

    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        // 自定义拦截器，添加拦截路径和排除拦截路径
        registry.addInterceptor(loggerInterceptor);
    }
}
