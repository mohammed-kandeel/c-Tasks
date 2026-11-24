using GymManagement.Entities.Enums;
namespace GymManagement.Entities;

public class Trainer : GymUser
{
    public DateTime HireDate { get; set; }
    public Specialties Specialties { get; set; }

    // Relationship
    public ICollection<Session> Sessions { get; set; } = default!;
}
