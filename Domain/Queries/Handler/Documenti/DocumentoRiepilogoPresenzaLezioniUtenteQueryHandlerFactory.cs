using System.Collections.Generic;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Documenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Documenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Documenti
{
    public static class DocumentoRiepilogoPresenzaLezioniUtenteQueryHandlerFactory
    {
       public static IQueryHandler<DocumentoRiepilogoPresenzaLezioniUtenteQuery, DocumentoRiepilogoPresenzaLezioniUtenteDTO> Build(DocumentoRiepilogoPresenzaLezioniUtenteQuery query, DocumentiBusiness business)
        {
            return new DocumentoRiepilogoPresenzaLezioniUtenteQueryHandler(query, business);
        }
    }
}
