using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Strutture
{
    public class OneStrutturaQuery : IQuery<StrutturaDTO>
    {
        public Guid ID { get; private set; }
        public OneStrutturaQuery(Guid id)
        {
            ID = id;
        }
    }
}
