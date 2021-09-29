using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCorsi
{
    public static class UtenteCalendarioCorsoQueryHandlerFactory
    {
        public static IQueryHandler<AllUtentiCalendariCorsiQuery, IEnumerable<UtenteCalendarioCorsoDTO>> Build(AllUtentiCalendariCorsiQuery query, UtentiCalendariCorsiBusiness business)
        {
            return new AllUtentiCalendariCorsiQueryHandler(business);
        }

        public static IQueryHandler<OneUtenteCalendarioCorsoQuery, UtenteCalendarioCorsoDTO> Build(OneUtenteCalendarioCorsoQuery query, UtentiCalendariCorsiBusiness business)
        {
            return new OneUtenteCalendarioCorsoQueryHandler(query, business);
        }
        
        public static IQueryHandler<UtenteCalendariCorsiQuery, UtenteCalendariCorsiDTO> Build(UtenteCalendariCorsiQuery query, UtentiCalendariCorsiBusiness business)
        {
            return new UtenteCalendariCorsiQueryHandler(query, business);
        }
        
        public static IQueryHandler<UtentiCalendarioCorsoQuery, UtentiCalendarioCorsoDTO> Build(UtentiCalendarioCorsoQuery query, UtentiCalendariCorsiBusiness business)
        {
            return new UtentiCalendarioCorsoQueryHandler(query, business);
        }
    }
}
