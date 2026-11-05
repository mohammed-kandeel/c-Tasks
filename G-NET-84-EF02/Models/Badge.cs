using G_NET_84_EF02.Enums;
namespace G_NET_84_EF02.Models;

internal class Badge
{
    public int Id { get; set; }
    public int BadgeNumber { get; set; }
    public DateTime IssueDate { get; set; }
    public BadgeTier Tier { get; set; }

    #region Attendee – Badge 
    public Attendee Attendee { get; set; } = null!;
    public int AttendeeId { get; set; }
    #endregion
}
