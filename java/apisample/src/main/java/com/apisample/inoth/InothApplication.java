package com.apisample.inoth;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
@MapperScan("com.apisample.inoth.mapper")
public class InothApplication {

    public static void main(String[] args) {
        SpringApplication.run(InothApplication.class, args);
    }

}
