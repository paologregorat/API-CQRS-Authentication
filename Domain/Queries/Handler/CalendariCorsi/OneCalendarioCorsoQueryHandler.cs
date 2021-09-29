using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.CalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.CalendariCorsi
{
    public class OneCalendarioCorsoQueryHandler : IQueryHandler<OneCalendarioCorsoQuery, CalendarioCorsoDTO>
    {
        private readonly OneCalendarioCorsoQuery _query;
        private readonly CalendariCorsiBusiness _business;
        public OneCalendarioCorsoQueryHandler(OneCalendarioCorsoQuery query, CalendariCorsiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public CalendarioCorsoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
