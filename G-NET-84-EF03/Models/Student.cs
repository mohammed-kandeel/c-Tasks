namespace G_NET_84_EF03.Models;

internal class Student : Person
{
    public DateOnly DateOfBirth { get; set; }

    //Student - Enrollment | one(mandatory) - many(optional)
    public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
}
