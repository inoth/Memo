package com.apisample.inoth.service.impl;

import com.apisample.inoth.mapper.BaseMapper;
import org.springframework.beans.factory.annotation.Autowired;

public abstract class BaseServiceImpl<M extends BaseMapper, Entity> {
    @Autowired
    protected M mapper;

    public Entity query(String id) {
        return (Entity) this.mapper.query(id);
    }
}
