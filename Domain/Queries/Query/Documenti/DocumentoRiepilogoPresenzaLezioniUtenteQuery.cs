using System;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Query.Documenti
{
    public class DocumentoRiepilogoPresenzaLezioniUtenteQuery : IQuery<DocumentoRiepilogoPresenzaLezioniUtenteDTO>
    {
        public Guid UtenteID { get; private set; }
        public DocumentoRiepilogoPresenzaLezioniUtenteQuery(Guid utenteID)
        {
            UtenteID = utenteID;
        }
    }
}
