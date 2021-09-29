using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.Corsi
{
    public class OneCorsoQueryHandler : IQueryHandler<OneCorsoQuery, CorsoDTO>
    {
        private readonly OneCorsoQuery _query;
        private readonly CorsiBusiness _business;
        public OneCorsoQueryHandler(OneCorsoQuery query, CorsiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public CorsoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
