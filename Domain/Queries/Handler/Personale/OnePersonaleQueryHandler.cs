using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Personale;

namespace WebAPI_CQRS.Domain.Queries.Handler.Personale
{
    public class OnePersonaleQueryHandler : IQueryHandler<OnePersonaleQuery, PersonaleDTO>
    {
        private readonly OnePersonaleQuery _query;
        private readonly PersonaleBusiness _business;
        public OnePersonaleQueryHandler(OnePersonaleQuery query, PersonaleBusiness business)
        {
            _query = query;
            _business = business;
        }
        public PersonaleDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
