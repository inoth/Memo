package inoth.webapi.Mapper;

import inoth.webapi.Model.Banner;
import java.util.List;
import org.apache.ibatis.annotations.Param;

public interface IBannerMapper extends IMainMapper<Banner> {

  List<Banner> getBannerByPage(@Param("pageNo") int pageNo);
}
