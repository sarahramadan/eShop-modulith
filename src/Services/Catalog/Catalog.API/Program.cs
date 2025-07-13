
using Catalog.API.Category;
using Catalog.API.Category.CreateCategory;
using Catalog.API.Category.GetCategory;
using Catalog.API.Products.CreateProduct;
using SharedBlock.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly/*Assembly.GetExecutingAssembly()*/);
});

// register CQRS services
builder.Services.RegisterCQRSDependencies();
builder.Services.AddScoped<ICommandHandler<CreateCategoryCommand>, CreateCategoryHandler>();
builder.Services.AddScoped<IQueryHandler<GetCategoryById, Catalog.API.Models.Category>, GetCategoryHandler>();

var app = builder.Build();

// register routing
var group = app.MapGroup("/api").WithTags("Public");

var productGroup = group.MapGroup("/products").WithTags("Product");
productGroup.MapProductEndpoints();

var categoryGroup = group.MapGroup("/categories").WithTags("Category");
categoryGroup.MapCategoryEndpoints();

app.Run();