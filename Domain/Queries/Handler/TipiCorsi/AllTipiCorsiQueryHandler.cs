using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.TipiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiCorsi
{
    public class AllTipiCorsiQueryHandler : IQueryHandler<AllTipiCorsiQuery, IEnumerable<TipoCorsoDTO>>
    {
        private readonly TipiCorsiBusiness _business;

        public AllTipiCorsiQueryHandler(TipiCorsiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<TipoCorsoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
