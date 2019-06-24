package inoth.webapi;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;

@SpringBootApplication
@MapperScan("inoth.webapi.Mapper")
public class WebapiApplication {

  public static void main(String[] args) {
    SpringApplication.run(WebapiApplication.class, args);
  }
}
