using EFCore_2.Configuration;
using EFCore_2.Models;
using Microsoft.EntityFrameworkCore;


namespace EFCore_2.Contexts;

internal class AppDbContext : DbContext
{
    public AppDbContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=EF_Core_2;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Employee

        ////Employee – Fluent API Requirements
        ////   1. Employee Table
        ////       - The table name in the database must be Employees.
        //modelBuilder.Entity<Employee>().ToTable("Employees");

        ////   2. EmpId
        ////       - Must be the Primary Key.
        ////       - Must be generated automatically when a new Employee is added (Identity).
        ////       - The column name in the database must be EmployeeId.
        //modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
        //modelBuilder.Entity<Employee>().Property(e => e.EmpId).HasColumnName("EmployeeId").UseIdentityColumn();

        ////   3. EmpName
        ////       - Must be Required.
        ////       - Maximum length: 100 characters.
        //modelBuilder.Entity<Employee>().Property(e => e.EmpName).IsRequired().HasMaxLength(100);

        ////   4. Salary
        ////       - Must be Required.
        ////       - SQL Server data type: decimal(10,2).

        ////       - Create an Index on this property.   yet---------------->
        
        ////       - Default value: 5000.
        //modelBuilder.Entity<Employee>().Property(e => e.Salary).IsRequired().HasPrecision(10, 2).HasDefaultValue(5000);
        //modelBuilder.Entity<Employee>().HasIndex(e => e.Salary);

        ////   5. Age
        ////       - Must be Required.
        ////       - Must be between 18 and 60.
        ////       - Default value: 18.
        //modelBuilder.Entity<Employee>().Property(e=>e.Age).IsRequired().HasDefaultValue(18);
        //modelBuilder.Entity<Employee>().ToTable(t => t.HasCheckConstraint("Check_Eployee_Age", "Age between 18 and 60"));

        ////   6. Email
        ////       - Must be Required.
        ////       - Maximum length: 150 characters.
        ////       - Must be Unique.
        //modelBuilder.Entity<Employee>().Property(e => e.Email).IsRequired().HasMaxLength(150);
        //modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();

        ////   7. Password
        ////       - Must be Optional.
        ////       - Maximum length: 255 characters.
        ////       - SQL Server data type: varchar(255).
        //modelBuilder.Entity<Employee>().Property(e => e.Password).IsRequired(false).HasMaxLength(255).HasColumnType("varchar(255)");


        ////   8. PhoneNumber
        ////       - Must be Required.
        ////       - Maximum length: 15 characters.
        //modelBuilder.Entity<Employee>().Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);


        ////   9. UserName
        ////       - not mapped prop
        //modelBuilder.Entity<Employee>().Ignore(e => e.UserName);


        //// 10. created at
        ////      - shadow prop
        //modelBuilder.Entity<Employee>().Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
        #endregion
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());




    }


    DbSet<Employee> Employees { get; set; }
}

