using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configurations;

public class PlanConfigurations : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

        builder.ToTable(T =>
        {
            T.HasCheckConstraint("PlanDurationCheck", "DurationDays between 1 and 365");
        });
    }
}
