using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Personale;

namespace WebAPI_CQRS.Domain.Queries.Handler.Personale
{
    public static class PersonaleQueryHandlerFactory
    {
        public static IQueryHandler<AllPersonaleQuery, IEnumerable<PersonaleDTO>> Build(AllPersonaleQuery query, PersonaleBusiness business)
        {
            return new AllPersonaleQueryHandler(business);
        }

        public static IQueryHandler<OnePersonaleQuery, PersonaleDTO> Build(OnePersonaleQuery query, PersonaleBusiness business)
        {
            return new OnePersonaleQueryHandler(query, business);
        }
    }
}
