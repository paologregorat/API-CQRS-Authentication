using System.Collections.Generic;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Utenti
{
    public class AllUtentiQueryHandler : IQueryHandler<AllUtentiQuery, IEnumerable<UtenteDTO>>
    {
        private readonly UtentiBusiness _business;

        public AllUtentiQueryHandler(UtentiBusiness business)
        { 
            _business = business;
        }
        public IEnumerable<UtenteDTO> Get()
        {
            return _business.GetAll();
        }
    }
}
