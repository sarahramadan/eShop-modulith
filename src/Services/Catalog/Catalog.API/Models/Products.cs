namespace Catalog.API.Models;

public class Product
{
    public Guid Id { get; set; }
    //note: before c# 8 can assign null to reference type but after this version compiler raise warning 
    // so need explicity to allow nullable 
    // string name = default; --> compile warning
    // string name = default!; --> tell compiler its technically null but its okey
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
    public decimal Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
}
