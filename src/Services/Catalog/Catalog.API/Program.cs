
using Catalog.API.Products.CreateProduct;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly/*Assembly.GetExecutingAssembly()*/);
});

//windows CMD: set DOTNET_ENVIRONMENT=Testing
//windows CMD: dotnet run --no-launch-profile
// app.UseUrls() - dotnet run --urls "http://..." - ASPNETCORE_URLS override by kestrel configuration 
var kestrelConfig = builder.Configuration.GetSection("Kestrel");
Console.WriteLine($"Environment : {builder.Environment.EnvironmentName}");
builder.WebHost.ConfigureKestrel(options =>
{
    options.Configure(kestrelConfig);
    //options.ListenAnyIP(5010); // HTTP on all interfaces
});

//Windows CMD: set ASPNETCORE_URLS=http://localhost:5000  if launchsettingis exist it will override this command
//from CLI command  dotnet run --urls "http://localhost:6000" ->  priority 4
//builder.WebHost.UseUrls("http://localhost:7000"); // priority 3

var app = builder.Build();

// register routing
var group =app.MapGroup("/api");
group.MapProductsAPIs();

//app.Urls.Add("http://localhost:8000");// priority 2
app.Run(/*"http://localhost:9000"*/); // priority 1