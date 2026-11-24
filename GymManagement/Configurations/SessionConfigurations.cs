using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymManagement.Configuration;

public class SessionConfigurations : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("SessionCapacityConstraint", "Capacity between 1 and 25");
            t.HasCheckConstraint("SessionEndDateAfterStartDate", "EndDate > StartDate");
        });

        builder.HasOne(s => s.Trainer)  
               .WithMany(t => t.Sessions)
               .HasForeignKey(s => s.TrainerId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
