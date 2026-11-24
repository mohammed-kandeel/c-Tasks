using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configurations;

public class TrainerConfigurations : GymUserConfigurations<Trainer>, IEntityTypeConfiguration<Trainer>
{
    public new void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.Property(t => t.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        base.Configure(builder);
    }
}
