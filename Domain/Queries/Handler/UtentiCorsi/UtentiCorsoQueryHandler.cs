using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi
{
    public class UtentiCorsoQueryHandler : IQueryHandler<UtentiCorsoQuery, UtentiCorsoDTO>
    {
        private readonly UtentiCorsiBusiness _business;
        private readonly UtentiCorsoQuery _query;

        public UtentiCorsoQueryHandler(UtentiCorsoQuery query, UtentiCorsiBusiness business)
        { 
            _business = business;
            _query = query;
        }
        public UtentiCorsoDTO Get()
        {
            return _business.GetUtentiCorso(_query.ID);
        }
    }
}
