using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.TipiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiCorsi
{
    public class OneTipoCorsoQueryHandler : IQueryHandler<OneTipoCorsoQuery, TipoCorsoDTO>
    {
        private readonly OneTipoCorsoQuery _query;
        private readonly TipiCorsiBusiness _business;
        public OneTipoCorsoQueryHandler(OneTipoCorsoQuery query, TipiCorsiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public TipoCorsoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
