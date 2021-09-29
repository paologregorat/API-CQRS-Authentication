using System.Collections.Generic;
using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Movimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Movimenti
{
    public class AllMovimentiQueryHandler : IQueryHandler<AllMovimentiQuery, IEnumerable<MovimentoDTO>>
    {
        private readonly MovimentiBusiness _business;

        public AllMovimentiQueryHandler(MovimentiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<MovimentoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
