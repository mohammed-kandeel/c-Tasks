using GymManagement.Entities.Enums;
namespace GymManagement.Entities;

public class GymUser : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
}
