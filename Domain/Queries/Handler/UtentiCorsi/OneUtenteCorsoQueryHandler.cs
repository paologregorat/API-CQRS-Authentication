using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi
{
    public class OneUtenteCorsoQueryHandler : IQueryHandler<OneUtenteCorsoQuery, UtenteCorsoDTO>
    {
        private readonly OneUtenteCorsoQuery _query;
        private readonly UtentiCorsiBusiness _business;
        public OneUtenteCorsoQueryHandler(OneUtenteCorsoQuery query, UtentiCorsiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public UtenteCorsoDTO Get()
        {
            return _business.GetById(_query.ID);

        }
    }
}
