package inoth.dbdemo.afflatus.Service;

import java.util.List;

public interface IMainService<T> {
  T Query(long id);
  List<T> QueryAll();
}
