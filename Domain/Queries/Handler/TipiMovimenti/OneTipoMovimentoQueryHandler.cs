using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiMovimenti
{
    public class OneTipoMovimentoQueryHandler : IQueryHandler<OneTipoMovimentoQuery, TipoMovimentoDTO>
    {
        private readonly OneTipoMovimentoQuery _query;
        private readonly TipiMovimentiBusiness _business;
        public OneTipoMovimentoQueryHandler(OneTipoMovimentoQuery query, TipiMovimentiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public TipoMovimentoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
