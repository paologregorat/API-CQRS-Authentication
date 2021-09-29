using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCalendariCorsi
{
    public class UtenteCalendariCorsiQueryHandler : IQueryHandler<UtenteCalendariCorsiQuery, UtenteCalendariCorsiDTO>
    {
        private readonly UtentiCalendariCorsiBusiness _business;
        private readonly UtenteCalendariCorsiQuery _query;

        public UtenteCalendariCorsiQueryHandler(UtenteCalendariCorsiQuery query, UtentiCalendariCorsiBusiness business)
        { 
            _business = business;
            _query = query;
        }
        public UtenteCalendariCorsiDTO Get()
        {
            return _business.GetUtenteCalendariCorsi(_query.ID);
        }
    }
}
