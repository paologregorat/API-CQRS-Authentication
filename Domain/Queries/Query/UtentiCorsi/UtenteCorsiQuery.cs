using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi
{
    public class UtenteCorsiQuery : IQuery<UtenteCorsiDTO>
    {
        public Guid ID { get; private set; }
        public UtenteCorsiQuery(Guid id)
        {
            ID = id;
        }
    }
}
