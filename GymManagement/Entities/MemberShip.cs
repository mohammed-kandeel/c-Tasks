using System.ComponentModel.DataAnnotations.Schema;
namespace GymManagement.Entities;

public class MemberShip : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [NotMapped]
    public string Status => StartDate > DateTime.Now ? "UpComing" :
                            EndDate > DateTime.Now ? "Active" :
                            "Expired";
    // Relationship
    public int MemberId { get; set; }
    public Member Member { get; set; } = default!;

    public int PlanId { get; set; }
    public Plan Plan { get; set; } = default!;
}
