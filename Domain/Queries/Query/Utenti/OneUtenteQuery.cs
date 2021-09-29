using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query
{
    public class OneUtenteQuery : IQuery<UtenteDTO>
    {
        public Guid ID { get; private set; }
        public OneUtenteQuery(Guid id)
        {
            ID = id;
        }
    }
}
