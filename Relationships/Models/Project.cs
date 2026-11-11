using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;
internal class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    #region Work_on relationship [ one Optional - many Optional]
    [InverseProperty(nameof(EmployeeProject.Project))]
    public ICollection<EmployeeProject>? EmployeeProjects { get; set; }=new HashSet<EmployeeProject>();
    #endregion

}
