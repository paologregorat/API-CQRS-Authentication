using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Corsi
{
    public class OneCorsoQuery : IQuery<CorsoDTO>
    {
        public Guid ID { get; private set; }
        public OneCorsoQuery(Guid id)
        {
            ID = id;
        }
    }
}
