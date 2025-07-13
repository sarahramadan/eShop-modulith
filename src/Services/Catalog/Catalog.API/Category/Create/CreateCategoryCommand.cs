namespace Catalog.API.Category.CreateCategory;

public record CreateCategoryCommand(string Name,string Description,string ImagePath): SharedBlock.CQRS.ICommand;
