package inoth.demo.logdemo.Config;

import inoth.demo.logdemo.Utility.ILoggerUtils;
import inoth.demo.logdemo.Utility.LogFileName;
import inoth.demo.logdemo.Utility.LoggerUtils;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class UtilsConfig {

  @Bean(value = "INOTHA")
  public ILoggerUtils getINOTHALog() {
    return new LoggerUtils(LogFileName.INOTHA);
  }
}

