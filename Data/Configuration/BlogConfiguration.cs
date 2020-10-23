using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.Configuration
{
    public class BlogConfiguration: IEntityTypeConfiguration<Blog>
    {

        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(x => x.BlogId);

            builder.Property(x => x.BlogId).HasColumnName(@"BlogId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Url).HasColumnName(@"Url").HasColumnType("varchar(1000)").IsRequired();
          
            
            builder.HasMany(a => a.Posts).WithOne(b => b.Blog);

        }   
    }
}
