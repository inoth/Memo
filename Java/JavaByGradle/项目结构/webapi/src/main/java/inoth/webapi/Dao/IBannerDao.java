package inoth.webapi.Dao;

import inoth.webapi.Model.Banner;
import java.util.List;

public interface IBannerDao extends IMainDao<Banner> {

  List<Banner> getBannerforPage(int pageNo);
}
