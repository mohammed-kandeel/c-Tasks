using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Models;

namespace Relationships.Configuration;

internal class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(e => e.DeptId).HasName("DepartmentId");



        // Configure the one-to-one relationship between Department and Employee ( Manager )
        builder
            .HasOne(d => d.Manager)
            .WithOne(e => e.ManagedDepartment)
            .HasForeignKey<Department>(d => d.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
