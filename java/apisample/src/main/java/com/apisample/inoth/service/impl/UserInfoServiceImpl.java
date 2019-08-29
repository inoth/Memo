package com.apisample.inoth.service.impl;

import com.apisample.inoth.mapper.UserInfoMapper;
import com.apisample.inoth.service.UserInfoServiceInterface;
import org.springframework.stereotype.Service;

@Service
public class UserInfoServiceImpl extends BaseServiceImpl<UserInfoMapper, Object> implements UserInfoServiceInterface {
}
