using G_NET_84_EF03.Configuration;
using G_NET_84_EF03.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace G_NET_84_EF03.Contexts;

internal class AppDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "OnlineLearningPlatform",
            TrustServerCertificate = true,
            IntegratedSecurity = true
        };
        optionsBuilder.UseSqlServer(builder.ConnectionString);
        //optionsBuilder.UseSqlServer("Server=.;Database=OnlineLearningPlatform;Trusted_Connection=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new InstructorConfig());
        modelBuilder.ApplyConfiguration(new CategoryConfig());
        modelBuilder.ApplyConfiguration(new CourseConfig());
        modelBuilder.ApplyConfiguration(new StudentConfig());
        modelBuilder.ApplyConfiguration(new EnrollmentConfig());
    }
}