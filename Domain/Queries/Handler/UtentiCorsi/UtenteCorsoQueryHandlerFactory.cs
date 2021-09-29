using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi
{
    public static class UtenteCorsoQueryHandlerFactory
    {
        public static IQueryHandler<AllUtentiCorsiQuery, IEnumerable<UtenteCorsoDTO>> Build(AllUtentiCorsiQuery query, UtentiCorsiBusiness business)
        {
            return new AllUtentiCorsiQueryHandler(business);
        }

        public static IQueryHandler<OneUtenteCorsoQuery, UtenteCorsoDTO> Build(OneUtenteCorsoQuery query, UtentiCorsiBusiness business)
        {
            return new OneUtenteCorsoQueryHandler(query, business);
        }
        
        public static IQueryHandler<UtenteCorsiQuery, UtenteCorsiDTO> Build(UtenteCorsiQuery query, UtentiCorsiBusiness business)
        {
            return new UtenteCorsiQueryHandler(query, business);
        }
        
        public static IQueryHandler<UtentiCorsoQuery, UtentiCorsoDTO> Build(UtentiCorsoQuery query, UtentiCorsiBusiness business)
        {
            return new UtentiCorsoQueryHandler(query, business);
        }
    }
}
