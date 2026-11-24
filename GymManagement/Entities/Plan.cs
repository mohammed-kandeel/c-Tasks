namespace GymManagement.Entities;

public class Plan : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int DurationDays { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }

    // Relationship
    public ICollection<MemberShip> PlanSubscriptions { get; set; } = default!;
}