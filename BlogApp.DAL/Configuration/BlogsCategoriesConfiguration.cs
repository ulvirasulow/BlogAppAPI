using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.DAL.Configuration
{
    public class BlogsCategoriesConfiguration : IEntityTypeConfiguration<BlogsCategories>
    {
        public void Configure(EntityTypeBuilder<BlogsCategories> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.BlogsCategories)
                .HasForeignKey(x => x.CategoryId);


            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogsCategories)
                .HasForeignKey(x => x.BlogId);

            builder.Ignore(x => x.IsDeleted);
        }
    }
}
