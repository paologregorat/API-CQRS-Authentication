using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi
{
    public class UtenteCalendariCorsiQuery : IQuery<UtenteCalendariCorsiDTO>
    {
        public Guid ID { get; private set; }
        public UtenteCalendariCorsiQuery(Guid id)
        {
            ID = id;
        }
    }
}
