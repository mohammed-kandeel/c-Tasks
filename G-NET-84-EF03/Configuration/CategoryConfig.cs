using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF03.Configuration;

internal class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(150);

        //Category - ParentCategory | many(optional) - one(optional) [self relation]
        builder.HasOne(c => c.ParentCategory)
            .WithMany()
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //seeding data 
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "Programming fundamentals",
                ParentCategoryId = null
            },
            new Category
            {
                Id = 2,
                Name = "Backend",
                Description = "Backend development",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 3,
                Name = "Frontend",
                Description = "Frontend development",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 4,
                Name = "ASP.NET Core",
                Description = "ASP.NET Core development",
                ParentCategoryId = 2
            },
            new Category
            {
                Id = 5,
                Name = "Angular",
                Description = "Angular development",
                ParentCategoryId = 3
            }
        );
    }
}
