using G_NET_84_EF01.Models;
using Microsoft.EntityFrameworkCore;

namespace G_NET_84_EF01.Contexts;

internal class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=G-NET-84-EF01;Trusted_Connection=true;TrustServerCertificate=true");
    }

    public DbSet<Book> Books { set; get; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}
