using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;
using Relationships.Configuration;
using Relationships.Models;
namespace Relationships.Contexts;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=Relationships;Trusted_Connection=True;TrustServerCertificate=True;");

        //var builder = new SqlConnectionStringBuilder
        //{
        //    DataSource = ".",
        //    InitialCatalog = "Relationships",
        //    TrustServerCertificate = true,
        //    IntegratedSecurity = true
        //};
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeConfig());
        modelBuilder.ApplyConfiguration(new DepartmentConfig());
        modelBuilder.ApplyConfiguration(new EmployeeCarConfig());
        modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students{ get; set; }
}
