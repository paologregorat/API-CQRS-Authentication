using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.TipiCorsi
{
    public class OneTipoCorsoQuery : IQuery<TipoCorsoDTO>
    {
        public Guid ID { get; private set; }
        public OneTipoCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
