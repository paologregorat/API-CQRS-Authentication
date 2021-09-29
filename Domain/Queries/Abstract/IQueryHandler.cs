using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Queries
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
    }
}
