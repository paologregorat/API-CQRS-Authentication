using System.Collections.Generic;
using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.CalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.CalendariCorsi
{
    public class AllCalendariCorsiQueryHandler : IQueryHandler<AllCalendariCorsiQuery, IEnumerable<CalendarioCorsoDTO>>
    {
        private readonly CalendariCorsiBusiness _business;

        public AllCalendariCorsiQueryHandler(CalendariCorsiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<CalendarioCorsoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
