using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Utenti;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Handler
{
    public static class UtenteQueryHandlerFactory
    {
        public static IQueryHandler<AllUtentiQuery, IEnumerable<UtenteDTO>> Build(AllUtentiQuery query, UtentiBusiness business)
        {
            return new AllUtentiQueryHandler(business);
        }

        public static IQueryHandler<OneUtenteQuery, UtenteDTO> Build(OneUtenteQuery query, UtentiBusiness business)
        {
            return new OneUtenteQueryHandler(query, business);
        }
    }
}
