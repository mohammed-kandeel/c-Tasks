namespace G_NET_84_EF02.Models;

internal class OrganizerProfile
{
    public int OrganizerId { get; set; } // PK && FK
    public string? Biography { get; set; }
    public string? Website { get; set; }
    public string? Logo { get; set; }

    #region Organizer – OrganizerProfile
    public Organizer Organizer { get; set; } = null!;
    #endregion
}
