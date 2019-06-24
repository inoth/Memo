package inoth.webapi.Dao.impl;

import inoth.webapi.Dao.IBannerDao;
import inoth.webapi.Mapper.IBannerMapper;
import inoth.webapi.Model.Banner;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;

public class Bannerimpl implements IBannerDao {


  @Autowired
  private IBannerMapper mper;


  @Override
  public List<Banner> getBannerforPage(int pageNo) {
    return mper.getBannerByPage(pageNo);
  }

  @Override
  public List<Banner> QueryAll() {
    return null;
  }
}
