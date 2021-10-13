using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Documenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Documenti;

namespace WebAPI_CQRS.Domain.Queries.Handler.Documenti
{
    public class DocumentiMovimentiUtenteQueryHandler : IQueryHandler<DocumentoMovimentiUtenteQuery, DocumentoMovimentiUtenteDTO>
    {
        private readonly DocumentoMovimentiUtenteQuery _query;
        private readonly DocumentiBusiness _business;
        public DocumentiMovimentiUtenteQueryHandler(DocumentoMovimentiUtenteQuery query, DocumentiBusiness business)
        {
            _query = query;
            _business = business;
        }
        public DocumentoMovimentiUtenteDTO Get()
        {
            return _business.GetDocumentoMovimentiUtente(_query.UtenteID);

        }
    }
}
