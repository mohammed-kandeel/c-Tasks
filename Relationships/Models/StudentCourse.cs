using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Relationships.Models;


[PrimaryKey(nameof(StudentId),nameof(CourseId))]
internal class StudentCourse
{

    public int Grade { get; set; }


    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }
    
    [InverseProperty(nameof(Student.StudentCourses))]
    public Student Student { get; set; } = null!;



    [ForeignKey(nameof(Course.Id))]
    public int CourseId { get; set; }

    [InverseProperty(nameof(Course.StudentCourses))]
    public Course Course { get; set; } = null!;
}
