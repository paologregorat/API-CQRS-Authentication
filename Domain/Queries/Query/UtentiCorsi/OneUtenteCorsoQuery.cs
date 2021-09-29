using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi
{
    public class OneUtenteCorsoQuery : IQuery<UtenteCorsoDTO>
    {
        public Guid ID { get; private set; }
        public OneUtenteCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
