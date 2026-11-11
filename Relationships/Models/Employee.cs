using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;

internal class Employee 
{
    public int EmpId { get; set; }
    public string? EmpName { get; set; } = null!;
    public decimal Salary { get; set; }
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string ?Password { get; set; }
    public string UserName { get; set; } = null!;


    #region Manage relationship [ one optional - one mendatory]
    //[InverseProperty(nameof(Department.Manager))]
    public Department? ManagedDepartment { get; set; }
    #endregion

    #region Adress relationship [ one mendatory - one mendatory]
    public Address EmpAddress { get; set; } = null!;
    #endregion

    #region [ one optional - one optional]   3 tables

    [InverseProperty(nameof(EmployeeCar.Employee))]
    public EmployeeCar EmployeeCar { get; set; } = null!;
    #endregion

    #region Work relationship [ one mendatory - many mendatory]
    //[ForeignKey(nameof(EmployeeDepartment))]
    public int DepartmentID { get; set; }

    //[InverseProperty(nameof(Department.Employees))]
    public Department EmployeeDepartment { get; set; } = null!;
    #endregion

    #region Work_on relationship [ one Optional - many Optional]
    [InverseProperty(nameof(EmployeeProject.Employee))]
    public EmployeeProject? EmployeeProject { get; set; } 
    #endregion

}
