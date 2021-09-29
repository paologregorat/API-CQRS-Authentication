using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Strutture;

namespace WebAPI_CQRS.Domain.Queries.Handler.Strutture
{
    public class OneStrutturaQueryHandler : IQueryHandler<OneStrutturaQuery, StrutturaDTO>
    {
        private readonly OneStrutturaQuery _query;
        private readonly StruttureBusiness _business;
        public OneStrutturaQueryHandler(OneStrutturaQuery query, StruttureBusiness business)
        {
            _query = query;
            _business = business;
        }
        public StrutturaDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
