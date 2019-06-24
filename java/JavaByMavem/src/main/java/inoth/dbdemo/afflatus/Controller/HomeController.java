package inoth.dbdemo.afflatus.Controller;

import com.alibaba.fastjson.JSON;
import inoth.dbdemo.afflatus.Model.Persona;
import inoth.dbdemo.afflatus.Service.IPersonaService;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {

  @Autowired
  private IPersonaService service;

  @RequestMapping(value = "/{id}", method = RequestMethod.GET)
  public Object Index(@PathVariable long id) {
    return JSON.toJSON(service.Query(id));
  }

  @RequestMapping(value = "/all", method = RequestMethod.GET)
  public Object QueryAll() {
    return JSON.toJSON(service.QueryAll());
  }

  @RequestMapping(value = "/name/{name}", method = RequestMethod.GET)
  public Object QueryByName(@PathVariable String name) {
    return JSON.toJSON(service.QueryByName(name));
  }

  @RequestMapping(value = "/test", method = RequestMethod.GET)
  public Object Test() {
    return JSON.toJSON(service.CallProcedures());
  }

}
