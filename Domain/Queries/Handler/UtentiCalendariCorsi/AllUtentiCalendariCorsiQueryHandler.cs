using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCorsi
{
    public class AllUtentiCalendariCorsiQueryHandler : IQueryHandler<AllUtentiCalendariCorsiQuery, IEnumerable<UtenteCalendarioCorsoDTO>>
    {
        private readonly UtentiCalendariCorsiBusiness _business;

        public AllUtentiCalendariCorsiQueryHandler(UtentiCalendariCorsiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<UtenteCalendarioCorsoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
