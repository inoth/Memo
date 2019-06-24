package inoth.dbdemo.afflatus.Config;

import inoth.dbdemo.afflatus.Service.IPersonaService;
import inoth.dbdemo.afflatus.Service.impl.PersonaService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class MainConfig {

  @Bean
  public IPersonaService CPersonaService() {
    return new PersonaService();
  }
}
