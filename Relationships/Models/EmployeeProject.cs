using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;
internal class EmployeeProject
{
    #region Work_on relationship [ one Optional - many Optional]
    [Key]
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    [InverseProperty(nameof(Employee.EmployeeProject))]
    public Employee Employee{ get; set; } = null!;

    [InverseProperty(nameof(Project.EmployeeProjects))]
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    #endregion
}
