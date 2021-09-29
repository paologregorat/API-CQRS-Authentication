using System.Collections.Generic;
using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiMovimenti
{
    public class AllTipiMovimentiQueryHandler : IQueryHandler<AllTipiMovimentiQuery, IEnumerable<TipoMovimentoDTO>>
    {
        private readonly TipiMovimentiBusiness _business;

        public AllTipiMovimentiQueryHandler(TipiMovimentiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<TipoMovimentoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
