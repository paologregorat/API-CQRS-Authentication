using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi
{
    public class UtentiCorsoQuery : IQuery<UtentiCorsoDTO>
    {
        public Guid ID { get; private set; }
        public UtentiCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
