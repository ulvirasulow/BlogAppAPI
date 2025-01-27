﻿using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<BlogsCategories> BlogsCategories { get; set; }
    }
}
