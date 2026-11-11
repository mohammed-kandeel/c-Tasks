using G_NET_84_EF03.Enums;
using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF03.Configuration;

internal class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(150);

        builder.Property(c => c.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        //Instructor - Course | many(optional) - one(mandatory) [publish]
        builder.HasOne(c => c.Instructor)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        //Category - Course | one(mandatory) - many(optional) [has]
        builder.HasOne(c => c.Category)
            .WithMany(ca => ca.Courses)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //-The published date is recorded only when the course gets published, so it is empty for unpublished courses. 
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Course_PublishedDate",
            "([PublishedDate] is not null and IsPublished = 1) or ([PublishedDate] is null and IsPublished = 0)"
        ));

        //seeding data
        builder.HasData(
            new Course
            {
                Id = 1,
                Title = "C# Fundamentals",
                Description = "Learn C# basics",
                Price = 500,
                Level = Level.Beginner,
                IsPublished = true,
                PublishedDate = new DateOnly(2025, 5, 1),
                InstructorId = 1,
                CategoryId = 2
            },
            new Course
            {
                Id = 2,
                Title = "ASP.NET Core Web API",
                Description = "Build Web APIs using ASP.NET Core",
                Price = 1200,
                Level = Level.Advanced,
                IsPublished = true,
                PublishedDate = new DateOnly(2025, 6, 1),
                InstructorId = 1,
                CategoryId = 4
            },
            new Course
            {
                Id = 3,
                Title = "SQL Server",
                Description = "Learn SQL Server database",
                Price = 700,
                Level = Level.Intermediate,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 3,
                CategoryId = 2
            },
            new Course
            {
                Id = 4,
                Title = "HTML & CSS",
                Description = "Learn web design fundamentals",
                Price = 400,
                Level = Level.Beginner,
                IsPublished = true,
                PublishedDate = new DateOnly(2025, 7, 1),
                InstructorId = 2,
                CategoryId = 3
            },
            new Course
            {
                Id = 5,
                Title = "Angular Fundamentals",
                Description = "Learn Angular framework",
                Price = 900,
                Level = Level.Intermediate,
                IsPublished = true,
                PublishedDate = new DateOnly(2025, 8, 1),
                InstructorId = 2,
                CategoryId = 5
            },
            new Course
            {
                Id = 6,
                Title = "Advanced Angular",
                Description = "Advanced Angular concepts",
                Price = 1500,
                Level = Level.Advanced,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 3,
                CategoryId = 5
            }
        );
    }
}
