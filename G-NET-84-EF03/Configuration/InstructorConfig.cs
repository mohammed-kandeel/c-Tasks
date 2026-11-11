using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF03.Configuration;

internal class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.Property(s => s.FullName)
        .IsRequired()
        .HasMaxLength(60);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Bio)
            .HasMaxLength(100);

        // seeding Data
        builder.HasData(
           new Instructor
           {
               Id = 1,
               FullName = "Ahmed Mohamed",
               Email = "ahmed@example.com",
               Bio = "Backend Developer",
               JoinedDate = new DateOnly(2025, 1, 10)
           },
           new Instructor
           {
               Id = 2,
               FullName = "Omar Ali",
               Email = "omar@example.com",
               Bio = "Frontend Developer",
               JoinedDate = new DateOnly(2025, 2, 15)
           },
           new Instructor
           {
               Id = 3,
               FullName = "Sara Hassan",
               Email = "sara@example.com",
               Bio = null,
               JoinedDate = new DateOnly(2025, 3, 20)
           }
       );
    }
}
