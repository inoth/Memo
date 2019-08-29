package com.apisample.inoth.service;

public interface BaseServiceInterface<Entity> {
    Entity query(String id);
}
