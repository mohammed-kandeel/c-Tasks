namespace G_NET_84_EF03.Models;

internal class Instructor : Person
{
    public string? Bio { get; set; }
    public DateOnly JoinedDate { get; set; }

    //Instructor - Course | many(optional) - one(mandatory) [publish]
    public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();
}
