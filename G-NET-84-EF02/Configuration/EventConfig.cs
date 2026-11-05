using G_NET_84_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace G_NET_84_EF02.Configuration;

internal class EventConfig : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Title)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(100);

        builder
            .Property(e => e.Description)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(500);

        builder
            .Property(e => e.StartDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder
            .Property(e => e.EndDate)
            .IsRequired(false)
            .HasColumnType("datetime");

        builder
            .Property(e => e.MaxAttendees)
            .IsRequired();

        builder
            .HasOne(o => o.Organizer)
            .WithMany(e => e.Events)
            .HasForeignKey(e => e.OrganizerId);
    }
}