using SharedBlock.CQRS;

namespace Catalog.API.Category.GetCategory;

public class GetCategoryHandler : IQueryHandler<GetCategoryById, Catalog.API.Models.Category>
{
    public Task<Models.Category> HandleQueryAsync(GetCategoryById query)
    {
        return Task.FromResult(new Models.Category { Id = query.Id });
    }
}
