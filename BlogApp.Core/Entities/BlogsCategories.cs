using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlogApp.Core.Entities.Common;

namespace BlogApp.Core.Entities
{
    public class BlogsCategories : BaseEntity
    {
        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
