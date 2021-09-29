using System.Collections.Generic;
using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Personale;

namespace WebAPI_CQRS.Domain.Queries.Handler.Personale
{
    public class AllPersonaleQueryHandler : IQueryHandler<AllPersonaleQuery, IEnumerable<PersonaleDTO>>
    {
        private readonly PersonaleBusiness _business;

        public AllPersonaleQueryHandler(PersonaleBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<PersonaleDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
