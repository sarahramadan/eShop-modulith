using SharedBlock.CQRS;
using Catalog.API.Models;
namespace Catalog.API.Category.CreateCategory;

public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand>
{
    public async Task HandleCommandAsync(CreateCategoryCommand command)
    {
        new Catalog.API.Models.Category()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            ImagePath = command.ImagePath
        };
        await Task.Delay(1000);
    }
}
