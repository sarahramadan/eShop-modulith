using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBlock.CQRS;
public interface IQueryHandler<TQuery,TResult> where TQuery: IQuery
{
    Task<TResult> HandleQueryAsync(TQuery query);
}
