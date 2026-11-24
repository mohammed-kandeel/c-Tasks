namespace GymManagement.Entities;

public class Address
{
    public int BuildingNumber { get; set; }
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
}
