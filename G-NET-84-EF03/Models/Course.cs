using G_NET_84_EF03.Enums;
namespace G_NET_84_EF03.Models;

internal class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Level Level { get; set; }
    public bool IsPublished { get; set; }
    public DateOnly? PublishedDate { get; set; }

    //Instructor - Course | many(optional) - one(mandatory) [publish]
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; } = null!;

    //Category - Course | one(mandatory) - many(optional) [has]
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    //Course - Enrollment | one(mandatory) - many(optional)
    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
}
