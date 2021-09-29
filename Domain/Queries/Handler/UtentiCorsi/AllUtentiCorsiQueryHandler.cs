using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi
{
    public class AllUtentiCorsiQueryHandler : IQueryHandler<AllUtentiCorsiQuery, IEnumerable<UtenteCorsoDTO>>
    {
        private readonly UtentiCorsiBusiness _business;

        public AllUtentiCorsiQueryHandler(UtentiCorsiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<UtenteCorsoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
