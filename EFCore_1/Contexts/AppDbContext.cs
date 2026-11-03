
using EFCore_1.Models;
using Microsoft.EntityFrameworkCore;
namespace EFCore_1.Contexts;

internal class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Connection string 
        //Should be added in appsettings [in gitignore]
        optionsBuilder.UseSqlServer("Server=.;Database=EF_Core_1;Trusted_Connection=True;TrustServerCertificate=True");
        //server =  . for local or url
        //Database = Database Name 
        //Trusted_Connection=True  --> Authentication =  Windows Authentication
        //TrustServerCertificate=True

        // old projects
        //optionsBuilder.UseSqlServer("Data Source=.;Intial Catalog=MyCompanyG01;Integrated Secuirty=True");
        //Data Source=
        //Intial Catalog
        //Integrated Secuirty

    }


    public DbSet<Product> Products { set; get; }
    public DbSet<Employee> Employees { get; set; }
}


// Add-Migration -Name "IntialCreate" -context "AppDbContext" -outputDir "Migrations"
// Name --> name of Migartion (Optional)
// context --> name of cotext for database (انهي داتا بيس هيتعامل معاها)
// outputDir --> اسم الملف الي هتحط فيه الملفات
// -outputDir "Migrations"   --> defult

