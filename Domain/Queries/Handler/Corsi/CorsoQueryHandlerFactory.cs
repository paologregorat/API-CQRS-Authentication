using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.Corsi
{
    public static class CorsoQueryHandlerFactory
    {
        public static IQueryHandler<AllCorsiQuery, IEnumerable<CorsoDTO>> Build(AllCorsiQuery query, CorsiBusiness business)
        {
            return new AllCorsiQueryHandler(business);
        }

        public static IQueryHandler<OneCorsoQuery, CorsoDTO> Build(OneCorsoQuery query, CorsiBusiness business)
        {
            return new OneCorsoQueryHandler(query, business);
        }
    }
}
