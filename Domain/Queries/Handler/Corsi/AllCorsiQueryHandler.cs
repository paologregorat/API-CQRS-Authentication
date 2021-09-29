using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.Corsi
{
    public class AllCorsiQueryHandler : IQueryHandler<AllCorsiQuery, IEnumerable<CorsoDTO>>
    {
        private readonly CorsiBusiness _business;

        public AllCorsiQueryHandler(CorsiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<CorsoDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
