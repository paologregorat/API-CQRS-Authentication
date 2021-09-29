using System.Collections.Generic;
using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.Movimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Movimenti
{
    public static class MovimentoQueryHandlerFactory
    {
        public static IQueryHandler<AllMovimentiQuery, IEnumerable<MovimentoDTO>> Build(AllMovimentiQuery query, MovimentiBusiness business)
        {
            return new AllMovimentiQueryHandler(business);
        }

        public static IQueryHandler<OneMovimentoQuery, MovimentoDTO> Build(OneMovimentoQuery query, MovimentiBusiness business)
        {
            return new OneMovimentoQueryHandler(query, business);
        }
    }
}
