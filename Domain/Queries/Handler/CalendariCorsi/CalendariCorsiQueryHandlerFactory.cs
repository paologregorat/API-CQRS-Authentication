using System.Collections.Generic;
using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.CalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Query.CalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.CalendariCorsi
{
    public static class CalendarioCorsoQueryHandlerFactory
    {
        public static IQueryHandler<AllCalendariCorsiQuery, IEnumerable<CalendarioCorsoDTO>> Build(AllCalendariCorsiQuery query, CalendariCorsiBusiness business)
        {
            return new AllCalendariCorsiQueryHandler(business);
        }

        public static IQueryHandler<OneCalendarioCorsoQuery, CalendarioCorsoDTO> Build(OneCalendarioCorsoQuery query, CalendariCorsiBusiness business)
        {
            return new OneCalendarioCorsoQueryHandler(query, business);
        }
    }
}
