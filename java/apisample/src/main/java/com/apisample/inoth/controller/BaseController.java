package com.apisample.inoth.controller;

import com.apisample.inoth.service.BaseServiceInterface;
import org.springframework.beans.factory.annotation.Autowired;

public class BaseController<Serve extends BaseServiceInterface> {
    @Autowired
    protected Serve service;
}
