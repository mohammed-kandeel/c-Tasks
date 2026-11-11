using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Relationships.Models;

// primary key is composite key
[PrimaryKey(nameof(CarId), nameof(EmployeeId))]
internal class EmployeeCar
{
    //or
    // with flount api we can create composite key in the configuration file,
    // so we don't need to use data annotation for composite key
    //builder.HasKey(ec => new { ec.CarId, ec.EmployeeId });

    [ForeignKey(nameof(Car))]
    public int CarId { get; set; }
    [InverseProperty(nameof(Car.EmployeeCar))]
    public Car Car { get; set; } = null!;

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    [InverseProperty(nameof(Employee.EmployeeCar))]
    public Employee Employee { get; set; } = null!;
}
