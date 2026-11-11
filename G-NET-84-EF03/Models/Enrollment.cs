using G_NET_84_EF03.Enums;
namespace G_NET_84_EF03.Models;

internal class Enrollment
{
    public DateOnly EnrollmentDate { get; set; }
    public decimal ProgressPercentage { get; set; }
    public Status Status { get; set; }
    public decimal? FinalGrade { get; set; }

    //Student - Enrollment | one(mandatory) - many(optional)
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    //Course - Enrollment | one(mandatory) - many(optional)
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}