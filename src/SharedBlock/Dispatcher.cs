using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SharedBlock.CQRS;
public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleCommandAsync(command);
    }

    public async Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
        return await handler.HandleQueryAsync(query);
    }
}
