using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF03.Configuration;

internal class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.FullName)
         .IsRequired()
         .HasMaxLength(60);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
