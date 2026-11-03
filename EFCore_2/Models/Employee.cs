namespace EFCore_2.Models;

internal class Employee
{
    public int EmpId { get; set; }
    public string? EmpName { get; set; }
    public decimal Salary { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }



    #region 1 mendatory to 1 optional [Manage relationship]
    //nav prop [one]  [optional]
    public Department? ManagedDepartment { get; set; }
    #endregion

}
