namespace GymManagement.Entities;

public class Member : GymUser
{
    public string? Photo { get; set; }

    // Relationship
    public ICollection<MemberShip> MemberSubscriptions { get; set; } = default!;
}
