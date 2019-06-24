package inoth.dbdemo.afflatus.DAO;

import inoth.dbdemo.afflatus.Model.Persona;
import java.util.List;
import java.util.Map;
import org.apache.ibatis.annotations.Param;

public interface IPersonaDao extends IMainDao<Persona> {

  Persona QueryByName(@Param("name") String name);

  void CallProcedures(Map<String, Object> map);

}
