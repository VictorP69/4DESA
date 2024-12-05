﻿using AutoMapper;
using social_media.DTO.User;
using social_media.DTO.Post;
using social_media.Models;
using Microsoft.AspNetCore.Identity;

namespace social_media
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<PostUserDto, User>();
            CreateMap<User, PostUserDto>();
            CreateMap<Post, PostDto>() ;
            CreateMap<PostDto, Post>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
