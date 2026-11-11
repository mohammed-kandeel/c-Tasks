using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Models;

namespace Relationships.Configuration;

internal class EmployeeProjectConfig : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder.ToTable("EmployeeProjects");

        builder.HasKey(ep => ep.EmployeeId);

        builder
            .HasOne(ep => ep.Employee)
            .WithOne(e => e.EmployeeProject)
            .HasForeignKey<EmployeeProject>(ep => ep.EmployeeId);

        builder
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);
    }
}
