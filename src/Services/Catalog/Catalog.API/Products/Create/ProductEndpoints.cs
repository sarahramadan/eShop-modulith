using Catalog.API.Models;
using static Catalog.API.Products.CreateProduct.CreateProductHandler;

namespace Catalog.API.Products.CreateProduct;

public static class ProductEndpoints
{
    // step1: add extension method to separate register routing in different file
    // step2: program file
    // WebBuilder implement IEndpointRouteBuilder and its more flexible to use 
    //IEndpointRouteBuilder preferred for reusable and using with test and grouped endpoints
    //The problem her i register route to root level so it appear 4 routes in Endpoint Explorer
    //Solution using RouteGroupBuilder  to outes register to group level and appear 2 routes in Endpoint Explorer
    public static IEndpointRouteBuilder MapProductEndpoints(this /*IEndpointRouteBuilder routes*/RouteGroupBuilder group)
    {
        group.MapGet("/", async () =>
        {
            return await Task.FromResult(new List<Product>());
        });
        group.MapPost("/", async (CreateProductCommand productCommand, IMediator mediator) =>
        {
            var response = await mediator.Send(productCommand);
            var xx = Results.Created("created", response);
            return Results.Created("created", response);
        });
        return group;
    }
}
