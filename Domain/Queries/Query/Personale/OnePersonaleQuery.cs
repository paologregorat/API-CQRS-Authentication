using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Personale
{
    public class OnePersonaleQuery : IQuery<PersonaleDTO>
    {
        public Guid ID { get; private set; }
        public OnePersonaleQuery(Guid id)
        {
            ID = id;
        }
    }
}
