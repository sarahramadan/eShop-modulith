using Catalog.API.Category.CreateCategory;
using Catalog.API.Category.GetCategory;
using Microsoft.AspNetCore.Mvc;
using SharedBlock.CQRS;
using System.Runtime.CompilerServices;

namespace Catalog.API.Category;

public static class CategoryEndpoints
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this RouteGroupBuilder routeGroup)
    {
        routeGroup.MapGet("/{id}", GetCategoryByIdAsync);

        routeGroup.MapPost("/", CreateCategoryAsync);
        return routeGroup;
    }
    public static async Task<IResult> GetCategoryByIdAsync(Guid id, [FromServices] IDispatcher dispatcher)
    {
        var response = await dispatcher.DispatchQueryAsync<GetCategoryById, Models.Category>(new GetCategoryById(id));
        return TypedResults.Ok(response);
    }
    public static async Task<IResult> CreateCategoryAsync(CreateCategoryCommand command, [FromServices] IDispatcher dispatcher)
    {
        await dispatcher.DispatchCommandAsync(command);
        return TypedResults.Created();
    }
}
