using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti
{
    public class OneTipoMovimentoQuery : IQuery<TipoMovimentoDTO>
    {
        public Guid ID { get; private set; }
        public OneTipoMovimentoQuery(Guid id)
        {
            ID = id;
        }
    }
}
