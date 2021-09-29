using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Serializer;

namespace WebAPI_CQRS.Domain.Queries.Handler
{
    public class OneUtenteQueryHandler : IQueryHandler<OneUtenteQuery, UtenteDTO>
    {
        private readonly OneUtenteQuery _query;
        private readonly UtentiBusiness _business;
        public OneUtenteQueryHandler(OneUtenteQuery query, UtentiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public UtenteDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
