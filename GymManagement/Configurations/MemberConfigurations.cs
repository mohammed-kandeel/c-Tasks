using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configurations;

public class MemberConfigurations : GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
{
    public new void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.Property(m => m.CreatedAt)
                      .HasDefaultValueSql("GETDATE()")
                      .HasColumnName("JoinDate");

        base.Configure(builder);
    }
}
