using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCorsi
{
    public class OneUtenteCalendarioCorsoQueryHandler : IQueryHandler<OneUtenteCalendarioCorsoQuery, UtenteCalendarioCorsoDTO>
    {
        private readonly OneUtenteCalendarioCorsoQuery _query;
        private readonly UtentiCalendariCorsiBusiness _business;
        public OneUtenteCalendarioCorsoQueryHandler(OneUtenteCalendarioCorsoQuery query, UtentiCalendariCorsiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public UtenteCalendarioCorsoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
