using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configurations;

public class MemberShipConfigurations : IEntityTypeConfiguration<MemberShip>
{
    public void Configure(EntityTypeBuilder<MemberShip> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");

        builder.HasOne(m => m.Member)
               .WithMany(x => x.MemberSubscriptions)
               .HasForeignKey(m => m.MemberId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Plan)
               .WithMany(x => x.PlanSubscriptions)
               .HasForeignKey(m => m.PlanId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
