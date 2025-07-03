using MediatR;
using static Catalog.API.Products.CreateProduct.CreateProductHandler;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public static class ProductsMinimalAPI
{
    public static void MapProductsAPIs(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/products", async () =>
        {
            return await Task.FromResult(new List<Product>());
        });
        app.MapPost("api/products", async (CreateProductCommand productCommand,IMediator mediator) =>
        {
            var response = await mediator.Send(productCommand);
            return response;
        });
    }
}
