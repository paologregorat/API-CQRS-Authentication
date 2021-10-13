using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Documenti
{
    public class DocumentoMovimentiUtenteQuery : IQuery<DocumentoMovimentiUtenteDTO>
    {
        public Guid UtenteID { get; private set; }
        public DocumentoMovimentiUtenteQuery(Guid utenteID)
        {
            UtenteID = utenteID;
        }
    }
}
