using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configurations;

public class GymUserConfigurations<T> : IEntityTypeConfiguration<T>where T :GymUser
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(g => g.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        
        builder.Property(g => g.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

        builder.Property(g => g.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

        builder.HasIndex(g => g.Email).IsUnique();
        builder.HasIndex(g => g.Phone).IsUnique();

        builder.ComplexProperty(g => g.Address);

        builder.ToTable(T =>
        {
            T.HasCheckConstraint("GymeUser_CheckEmail", "Email LIKE '_%@_%._%'");
            T.HasCheckConstraint("GymeUser_CheckPhone", "LEN(Phone) = 11 AND (phone LIKE '010%' OR phone LIKE '011%' OR phone LIKE '012%' OR phone LIKE '015%')");
        });
         
    }
}
