﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.DAL.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(u => u.Blogs)
                .HasForeignKey(x => x.AuthorId);

        }
    }
}
