using System.Collections.Generic;
using WebAPI_CQRS.Business.GenerazioneDocumenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Movimenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Documenti
{
    public class DocumentoSerializer : IDocumentoSerializer
    {
        public  DocumentoMovimentiUtenteDTO SerializeDocumentoMovimentiUtente(Documento documento)
        {
            var result = new DocumentoMovimentiUtenteDTO()
            {
                Documento = documento
            };
            return result;
        }

        public  DocumentoRiepilogoPresenzaLezioniUtenteDTO SerializeDocumentoRiepilogoPresenzaLezioniUtente(Documento documento)
        {
            var result = new DocumentoRiepilogoPresenzaLezioniUtenteDTO()
            {
                Documento = documento
            };
            return result;
        }
        
        
    }
}
