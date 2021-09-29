using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi
{
    public class OneUtenteCalendarioCorsoQuery : IQuery<UtenteCalendarioCorsoDTO>
    {
        public Guid ID { get; private set; }
        public OneUtenteCalendarioCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
