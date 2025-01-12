using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Blog> Blogs { get; set; }
    }
}
