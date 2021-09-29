using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi
{
    public class UtentiCalendarioCorsoQuery : IQuery<UtentiCalendarioCorsoDTO>
    {
        public Guid ID { get; private set; }
        public UtentiCalendarioCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
