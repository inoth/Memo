package inoth.dbdemo.afflatus.DAO;

import java.util.List;
import org.apache.ibatis.annotations.Param;

public interface IMainDao<T> {

  T QueryByID(@Param("id") long id);

  List<T> QueryAll();
}
