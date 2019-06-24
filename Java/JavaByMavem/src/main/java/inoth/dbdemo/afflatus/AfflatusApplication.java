package inoth.dbdemo.afflatus;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
@MapperScan("inoth.dbdemo.afflatus.DAO")
public class AfflatusApplication {

  public static void main(String[] args) {
    SpringApplication.run(AfflatusApplication.class, args);
  }
}
