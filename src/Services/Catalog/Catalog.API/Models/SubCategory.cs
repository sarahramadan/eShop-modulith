namespace Catalog.API.Models;

public class SubCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid CategoryId { get; set; }

}
