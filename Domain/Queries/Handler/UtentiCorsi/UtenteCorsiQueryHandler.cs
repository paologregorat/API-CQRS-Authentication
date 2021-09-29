using System.Collections.Generic;
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi
{
    public class UtenteCorsiQueryHandler : IQueryHandler<UtenteCorsiQuery, UtenteCorsiDTO>
    {
        private readonly UtentiCorsiBusiness _business;
        private readonly UtenteCorsiQuery _query;

        public UtenteCorsiQueryHandler(UtenteCorsiQuery query, UtentiCorsiBusiness business)
        { 
            _business = business;
            _query = query;
        }
        public UtenteCorsiDTO Get()
        {
            return _business.GetUtenteCorsi(_query.ID);
        }
    }
}
