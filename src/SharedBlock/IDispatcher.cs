using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBlock.CQRS;
public interface IDispatcher
{
    public  Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    public  Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
}
