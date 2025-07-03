
using Catalog.API.Models;
using MediatR;
using static Catalog.API.Products.CreateProduct.CreateProductHandler;

namespace Catalog.API.Products.CreateProduct;

public class CreateProductHandler:IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //note: Simulate asynchronous operation using Task.FromResult
        return await Task.FromResult(new Product() { Name = request.Name,Id = Guid.NewGuid()});
    }

    public record CreateProductCommand(Guid Id , string Name,string Description,Guid catergoryId,Guid subCategoryId,decimal price): IRequest<Product>;
}
