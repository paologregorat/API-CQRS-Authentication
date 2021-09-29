using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.CalendariCorsi
{
    public class OneCalendarioCorsoQuery : IQuery<CalendarioCorsoDTO>
    {
        public Guid ID { get; private set; }
        public OneCalendarioCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
