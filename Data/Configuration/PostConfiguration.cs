using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class PostConfiguration: IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.PostId);

            builder.Property(x => x.PostId).HasColumnName(@"PostId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("varchar(500)").IsRequired();
            builder.Property(x => x.Content).HasColumnName(@"Content").HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.BlogId).HasColumnName(@"BlogId").HasColumnType("int").IsRequired();
           
            builder.HasOne(a => a.Blog).WithMany(b => b.Posts).HasForeignKey(c => c.BlogId);

        }   
    }
}
