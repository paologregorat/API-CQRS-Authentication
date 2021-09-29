using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.TipiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiCorsi
{
    public static class TipoCorsoQueryHandlerFactory
    {
        public static IQueryHandler<AllTipiCorsiQuery, IEnumerable<TipoCorsoDTO>> Build(AllTipiCorsiQuery query, TipiCorsiBusiness business)
        {
            return new AllTipiCorsiQueryHandler(business);
        }

        public static IQueryHandler<OneTipoCorsoQuery, TipoCorsoDTO> Build(OneTipoCorsoQuery query, TipiCorsiBusiness business)
        {
            return new OneTipoCorsoQueryHandler(query, business);
        }
    }
}
