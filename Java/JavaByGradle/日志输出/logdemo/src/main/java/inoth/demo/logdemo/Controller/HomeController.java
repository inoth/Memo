package inoth.demo.logdemo.Controller;

import inoth.demo.logdemo.Utility.ILoggerUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {

  @Autowired
  @Qualifier("INOTHA")
  private ILoggerUtils logger;

  @RequestMapping(value = "/",method = RequestMethod.GET)
  public  String Index(){
    logger.info("日志输出 info");
    logger.error("日志输出 error");
//    Integer.parseInt("abc");
    return  "さらばだ";
  }
}
