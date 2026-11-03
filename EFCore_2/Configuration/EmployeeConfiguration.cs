using EFCore_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCore_2.Configuration;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        //Employee – Fluent API Requirements
        //   1. Employee Table
        //       - The table name in the database must be Employees.
        builder.ToTable("Employees");

        //   2. EmpId
        //       - Must be the Primary Key.
        //       - Must be generated automatically when a new Employee is added (Identity).
        //       - The column name in the database must be EmployeeId.
        builder.HasKey(e => e.EmpId);
        builder.Property(e => e.EmpId).HasColumnName("EmployeeId").UseIdentityColumn();

        //   3. EmpName
        //       - Must be Required.
        //       - Maximum length: 100 characters.
        builder.Property(e => e.EmpName).IsRequired().HasMaxLength(100);

        //   4. Salary
        //       - Must be Required.
        //       - SQL Server data type: decimal(10,2).

        //       - Create an Index on this property.   yet---------------->

        //       - Default value: 5000.
        builder.Property(e => e.Salary).IsRequired().HasPrecision(10, 2).HasDefaultValue(5000);
        builder.HasIndex(e => e.Salary);

        //   5. Age
        //       - Must be Required.
        //       - Must be between 18 and 60.
        //       - Default value: 18.
        builder.Property(e => e.Age).IsRequired().HasDefaultValue(18);
        builder.ToTable(t => t.HasCheckConstraint("Check_Eployee_Age", "Age between 18 and 60"));

        //   6. Email
        //       - Must be Required.
        //       - Maximum length: 150 characters.
        //       - Must be Unique.
        builder.Property(e => e.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(e => e.Email).IsUnique();

        //   7. Password
        //       - Must be Optional.
        //       - Maximum length: 255 characters.
        //       - SQL Server data type: varchar(255).
        builder.Property(e => e.Password).IsRequired(false).HasMaxLength(255).HasColumnType("varchar(255)");


        //   8. PhoneNumber
        //       - Must be Required.
        //       - Maximum length: 15 characters.
        builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);


        //   9. UserName
        //       - not mapped prop
        builder.Ignore(e => e.UserName);


        // 10. created at
        //      - shadow prop
        builder.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
    }
}
