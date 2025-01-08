using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewerCount { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<BlogsCategories> BlogsCategories { get; set; }
    }
}
