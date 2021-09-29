using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Movimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Movimenti
{
    public class OneMovimentoQueryHandler : IQueryHandler<OneMovimentoQuery, MovimentoDTO>
    {
        private readonly OneMovimentoQuery _query;
        private readonly MovimentiBusiness _business;
        public OneMovimentoQueryHandler(OneMovimentoQuery query, MovimentiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public MovimentoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
