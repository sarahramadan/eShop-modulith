
using Catalog.API.Products.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly/*Assembly.GetExecutingAssembly()*/);
});

var app = builder.Build();
app.MapProductsAPIs();
app.Run();