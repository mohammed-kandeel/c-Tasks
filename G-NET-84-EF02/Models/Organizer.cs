using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G_NET_84_EF02.Models;

[Table("EventOrganizers")]
internal class Organizer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string OrganizerName { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }
    public bool IsVerified { get; set; }

    #region Organizer – OrganizerProfile
    [InverseProperty(nameof(OrganizerProfile.Organizer))]
    public OrganizerProfile? OrganizerProfile { get; set; }
    #endregion

    #region Organizer – Event
    [InverseProperty(nameof(Event.Organizer))]
    public ICollection<Event>? Events { get; set; } = new HashSet<Event>();
    #endregion
}
