package com.apisample.inoth.controller;

import com.apisample.inoth.service.UserInfoServiceInterface;
import com.apisample.inoth.service.impl.UserInfoServiceImpl;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api")
public class UserInfoController extends BaseController<UserInfoServiceInterface> {

    @RequestMapping(value = "user/{id}", method = RequestMethod.GET)
    public Object query(@PathVariable String id) {
        return super.service.query(id);
    }
}
