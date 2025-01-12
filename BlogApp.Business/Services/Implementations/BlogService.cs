using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs.Blog;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        IBlogRepository repository;
        IMapper mapper;

        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<GetBlogDto> GetAll()
        {
            var blogs = repository.GetAll("Author", "BlogsCategories", "BlogsCategories.Category");
            var returnBlogs = mapper.Map<List<GetBlogDto>>(blogs);
            return returnBlogs;
        }
    }
}
