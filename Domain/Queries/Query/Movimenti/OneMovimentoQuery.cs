using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Movimenti
{
    public class OneMovimentoQuery : IQuery<MovimentoDTO>
    {
        public Guid ID { get; private set; }
        public OneMovimentoQuery(Guid id)
        {
            ID = id;
        }
    }
}
