using System.Collections.Generic;
using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.TipiMovimenti;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti;
using WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.TipiMovimenti
{
    public static class TipoMovimentoQueryHandlerFactory
    {
        public static IQueryHandler<AllTipiMovimentiQuery, IEnumerable<TipoMovimentoDTO>> Build(AllTipiMovimentiQuery query, TipiMovimentiBusiness business)
        {
            return new AllTipiMovimentiQueryHandler(business);
        }

        public static IQueryHandler<OneTipoMovimentoQuery, TipoMovimentoDTO> Build(OneTipoMovimentoQuery query, TipiMovimentiBusiness business)
        {
            return new OneTipoMovimentoQueryHandler(query, business);
        }
    }
}
