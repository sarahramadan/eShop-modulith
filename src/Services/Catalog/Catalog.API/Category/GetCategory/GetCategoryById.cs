using SharedBlock.CQRS;

namespace Catalog.API.Category.GetCategory;

public record GetCategoryById(Guid Id) : IQuery;
