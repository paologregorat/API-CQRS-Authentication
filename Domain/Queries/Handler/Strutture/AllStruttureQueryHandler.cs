using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Strutture;

namespace WebAPI_CQRS.Domain.Queries.Handler.Strutture
{
    public class AllStruttureQueryHandler : IQueryHandler<AllStruttureQuery, IEnumerable<StrutturaDTO>>
    {
        private readonly StruttureBusiness _business;

        public AllStruttureQueryHandler(StruttureBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<StrutturaDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
