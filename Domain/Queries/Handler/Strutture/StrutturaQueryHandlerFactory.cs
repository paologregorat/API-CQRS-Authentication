using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Strutture;

namespace WebAPI_CQRS.Domain.Queries.Handler.Strutture
{
    public static class StrutturaQueryHandlerFactory
    {
        public static IQueryHandler<AllStruttureQuery, IEnumerable<StrutturaDTO>> Build(AllStruttureQuery query, StruttureBusiness business)
        {
            return new AllStruttureQueryHandler(business);
        }

        public static IQueryHandler<OneStrutturaQuery, StrutturaDTO> Build(OneStrutturaQuery query, StruttureBusiness business)
        {
            return new OneStrutturaQueryHandler(query, business);
        }
    }
}
