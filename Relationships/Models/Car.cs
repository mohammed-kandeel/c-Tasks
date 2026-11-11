using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;
internal class Car
{
    public int Id{ get; set; }
    public string Model { get; set; } = null!;
    public string Color { get; set; } = null!;

    #region [ one optional - one optional]   3 tables

    [InverseProperty(nameof(EmployeeCar.Car))]
    public EmployeeCar EmployeeCar { get; set; } = null!;
    #endregion
}
