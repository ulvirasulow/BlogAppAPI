using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs.Blog;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IBlogService
    {
        public List<GetBlogDto> GetAll();
    }
}
