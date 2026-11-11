using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;
internal class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;


    //public ICollection<Student> Students { get; set; } = new HashSet<Student>();


    [InverseProperty(nameof(StudentCourse.Course))]
    public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
}
