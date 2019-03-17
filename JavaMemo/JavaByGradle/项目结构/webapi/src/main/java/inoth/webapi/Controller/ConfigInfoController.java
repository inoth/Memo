package inoth.webapi.Controller;

import ch.qos.logback.classic.Logger;
import com.alibaba.fastjson.JSON;
import inoth.webapi.Dao.IBannerDao;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ConfigInfoController {

//  private Logger log = (Logger) LoggerFactory.getLogger(this.getClass());

  @Autowired
  @Qualifier("getBannerDao")
  private IBannerDao dao;

  @RequestMapping(value = "/api/banner/{pageNo}", method = RequestMethod.GET)
  public Object BannerConfig(@PathVariable int pageNo) {
//    log.info("11111111111111111");
    return JSON.toJSON(dao.getBannerforPage(pageNo));

  }
}
