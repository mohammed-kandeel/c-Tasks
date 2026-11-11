using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Relationships.Models;

namespace Relationships.Configuration;

internal class EmployeeCarConfig : IEntityTypeConfiguration<EmployeeCar>
{
    public void Configure(EntityTypeBuilder<EmployeeCar> builder)
    {
        builder.ToTable("EmployeeCar");

        builder.HasKey(ec => new { ec.CarId, ec.EmployeeId });

        builder
            .HasOne(ec => ec.Car)
            .WithOne(c => c.EmployeeCar)
            .HasForeignKey<EmployeeCar>(ec => ec.CarId);

        builder
            .HasOne(ec=>ec.Employee)
            .WithOne(e=>e.EmployeeCar)
            .HasForeignKey<EmployeeCar>(ec => ec.EmployeeId);

    }
}
