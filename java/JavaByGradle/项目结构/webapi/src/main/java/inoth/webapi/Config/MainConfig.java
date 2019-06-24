package inoth.webapi.Config;

import inoth.webapi.Dao.IBannerDao;
import inoth.webapi.Dao.impl.Bannerimpl;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MainConfig {

  @Bean
  public IBannerDao getBannerDao() {
    return new Bannerimpl();
  }
}
