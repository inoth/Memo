package inoth.dbdemo.afflatus.Service.impl;


import inoth.dbdemo.afflatus.DAO.IPersonaDao;
import inoth.dbdemo.afflatus.Model.Persona;
import inoth.dbdemo.afflatus.Service.IPersonaService;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.RecursiveTask;
import org.springframework.beans.factory.annotation.Autowired;

public class PersonaService implements IPersonaService {

  @Autowired
  private IPersonaDao dao;

  @Override
  public Persona Query(long id) {
    return dao.QueryByID(id);
  }

  @Override
  public List<Persona> QueryAll() {
    return dao.QueryAll();
  }

  @Override
  public Persona QueryByName(String name) {
    return dao.QueryByName(name);
  }

  @Override
  public List<Persona> CallProcedures() {
    var map = new HashMap<String,Object>();
    map.put("v_id","1");
    dao.CallProcedures(map);
    return  (List<Persona>) map.get("v_out_cursor");
    //res.get("v_out_cursor");
  }
}
