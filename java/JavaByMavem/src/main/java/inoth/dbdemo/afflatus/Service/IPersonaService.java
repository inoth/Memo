package inoth.dbdemo.afflatus.Service;

import inoth.dbdemo.afflatus.Model.Persona;
import java.util.List;
import java.util.Map;

public interface IPersonaService extends IMainService<Persona> {

  Persona QueryByName(String name);

  List<Persona> CallProcedures();
}
