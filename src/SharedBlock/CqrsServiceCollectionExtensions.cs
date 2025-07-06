using Microsoft.Extensions.DependencyInjection;

namespace SharedBlock.CQRS;
public static class CqrsServiceCollectionExtensions
{
    public static void RegisterCQRSDependencies(this IServiceCollection serviceBuilder)
    {
        serviceBuilder.AddScoped<IDispatcher, Dispatcher>();
    }
}
