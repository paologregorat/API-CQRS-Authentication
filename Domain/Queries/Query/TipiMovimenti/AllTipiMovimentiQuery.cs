using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti
{
    public class AllTipiMovimentiQuery : IQuery<IEnumerable<TipoMovimentoDTO>>
    {
        
    }
}
