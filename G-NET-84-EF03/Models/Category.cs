using Microsoft.Extensions.Options;

namespace G_NET_84_EF03.Models;

internal class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }


    //Category - ParentCategory | many(optional) - one(optional) [self relation]
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    //Category - Course | one(mandatory) - many(optional) [has]
    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}
