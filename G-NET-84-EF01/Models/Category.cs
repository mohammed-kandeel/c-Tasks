namespace G_NET_84_EF01.Models;

internal class Category : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
}
