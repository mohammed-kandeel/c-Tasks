using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;
internal class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


    [InverseProperty(nameof(StudentCourse.Student))]
    public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
}
