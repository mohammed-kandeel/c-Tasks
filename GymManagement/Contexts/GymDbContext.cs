using GymManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace GymManagement.Context;

public class GymDbContext : DbContext
{
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("server=.; database=GymDb;trusted_Connection=true;trustServerCertificate=true");
    //}
    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    #region DbSets
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<MemberShip> MemberShips { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Plan> Plans { get; set; }
    #endregion
}
