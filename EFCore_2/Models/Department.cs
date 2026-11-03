namespace EFCore_2.Models;
internal class Department
{
    public int DptId { get; set; }
    public string DptName { get; set; }
    public DateTime DateOfCreation { get; set; }
    public int Serial { get; set; }

    #region 1 mendatory to 1 optional [Manage relationship]
    //nav prop [one]  [mendatory]
    public Employee Manager { get; set; } = null!;

    public int MyProperty { get; set; }
    #endregion
}
