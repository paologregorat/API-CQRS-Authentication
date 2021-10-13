using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Documenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Documenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Documenti
{
    public class DocumentoRiepilogoPresenzaLezioniUtenteQueryHandler : IQueryHandler<DocumentoRiepilogoPresenzaLezioniUtenteQuery, DocumentoRiepilogoPresenzaLezioniUtenteDTO>
    {
        private readonly DocumentoRiepilogoPresenzaLezioniUtenteQuery _query;
        private readonly DocumentiBusiness _business;
        public DocumentoRiepilogoPresenzaLezioniUtenteQueryHandler(DocumentoRiepilogoPresenzaLezioniUtenteQuery query, DocumentiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public DocumentoRiepilogoPresenzaLezioniUtenteDTO Get()
        {
            return _business.GetDocumentoRiepilogoPresenzaLezioni(_query.UtenteID);
        }
    }
}
