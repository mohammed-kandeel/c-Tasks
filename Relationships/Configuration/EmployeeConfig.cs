using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Models;

namespace Relationships.Configuration;

internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.EmpId).HasName("EmployeeId");

        #region Adress relationship [ one mendatory - one mendatory]
        builder.ComplexProperty(a => a.EmpAddress);
        #endregion

        #region Work relationship [ one mendatory - many mendatory]
        builder
            .HasOne(e => e.EmployeeDepartment)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentID);
        #endregion


    }
}
