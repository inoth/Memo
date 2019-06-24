package inoth.webapi.Dao;

import java.util.List;

public interface IMainDao<T> {
   List<T> QueryAll();
}
