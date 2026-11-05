using G_NET_84_EF02.Configuration;
using G_NET_84_EF02.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace G_NET_84_EF02.Contexts;

internal class AppDbContext : DbContext
{
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Attendee> Attendees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",  // for local SQL Server instance
            InitialCatalog = "EventHubDB",  // database name
            IntegratedSecurity = true, //for Windows Authentication
            TrustServerCertificate = true // for self-signed certificates
        };
        optionsBuilder.UseSqlServer(builder.ConnectionString);

        // or you can directly use the connection string like this:

        //optionsBuilder.UseSqlServer("server=.;database=EventHubDB;trusted_connection=true;trustservercertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrganizerProfile>(entity =>
        {
            entity.Property(op => op.Biography).HasMaxLength(500);
            entity.Property(op => op.Website).HasMaxLength(200);
            entity.Property(op => op.Logo).HasMaxLength(200);

            entity
            .HasKey(op => op.OrganizerId);

            entity
            .HasOne(op => op.Organizer)
            .WithOne(o => o.OrganizerProfile)
            .HasForeignKey<OrganizerProfile>(op => op.OrganizerId);
        });

        modelBuilder.ApplyConfiguration(new EventConfig());
        modelBuilder.ApplyConfiguration(new BadgeConfig());
    }
}