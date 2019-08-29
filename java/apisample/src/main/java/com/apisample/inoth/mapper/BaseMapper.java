package com.apisample.inoth.mapper;

import org.apache.ibatis.annotations.Param;

public interface BaseMapper<Entity> {
    Entity query(@Param("id") String id);
}
