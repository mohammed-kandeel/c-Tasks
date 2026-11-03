namespace G_NET_84_EF01.Models;

internal class Author : BaseEntity<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }

}
