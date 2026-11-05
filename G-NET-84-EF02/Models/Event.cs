namespace G_NET_84_EF02.Models;

internal class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int MaxAttendees { get; set; }

    #region Organizer – Event
    public Organizer Organizer { get; set; } = null!;
    public int OrganizerId { get; set; }
    #endregion  
}