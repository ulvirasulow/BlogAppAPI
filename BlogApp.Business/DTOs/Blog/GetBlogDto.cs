using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.Blog
{
    public record GetBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<Core.Entities.Category> Categories { get; set; }
    }
}
