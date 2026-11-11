using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;

internal class Department
{
    public int DeptId { get; set; }
    public string DeptName { get; set; } = null!;
    public DateTime DateOfCreation { get; set; }
    public int Serial { get; set; }

    #region Manage relationship [ one optional - one mendatory]
    //[ForeignKey(nameof(Manager))]
    public int ManagerId { get; set; }

    //[InverseProperty(nameof(Employee.ManagedDepartment))]
    public Employee Manager { get; set; } = null!;
    #endregion

    #region Work relationship [ one mendatory - many mendatory]
    //[InverseProperty(nameof(Employee.EmployeeDepartment))]
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    #endregion


}
