using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCorsi
{
    public class UtentiCalendarioCorsoQueryHandler : IQueryHandler<UtentiCalendarioCorsoQuery, UtentiCalendarioCorsoDTO>
    {
        private readonly UtentiCalendariCorsiBusiness _business;
        private readonly UtentiCalendarioCorsoQuery _query;

        public UtentiCalendarioCorsoQueryHandler(UtentiCalendarioCorsoQuery query, UtentiCalendariCorsiBusiness business)
        { 
            _business = business;
            _query = query;
        }
        public UtentiCalendarioCorsoDTO Get()
        {
            return _business.GetUtentiCalendarioCorso(_query.ID);
        }
    }
}
