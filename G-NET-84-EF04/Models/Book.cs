namespace G_NET_84_EF01.Models;

internal class Book : BaseEntity<int>
{
    public string Title { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public decimal Price { get; set; }
    public int NumberOfPages { get; set; }
    public int YearPublished { get; set; }
    public bool IsInStock { get; set; }

}
