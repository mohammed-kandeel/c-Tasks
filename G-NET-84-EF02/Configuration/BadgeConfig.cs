using G_NET_84_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF02.Configuration;

internal class BadgeConfig : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.BadgeNumber)
            .IsRequired();

        builder
            .HasIndex(b => b.BadgeNumber)
            .IsUnique();

        builder
            .Property(b => b.IssueDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder
            .Property(b => b.Tier)
            .IsRequired();

        builder
           .HasOne(b => b.Attendee)
           .WithOne(a => a.Badge)
           .HasForeignKey<Badge>(b => b.AttendeeId);
    }
}
