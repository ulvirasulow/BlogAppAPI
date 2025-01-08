using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs.Blog;
using BlogApp.Core.Entities;

namespace BlogApp.Business.Helpers.Mapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<GetBlogDto, Blog>().ReverseMap();
        }
    }
}
