using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_1.Models;



[Table("EmployeeTable")]
internal class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EmpId { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string? Name { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Salary { get; set; }
    public int Age { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? Password { get; set; }
    public string UserName{ get; set; }




}
