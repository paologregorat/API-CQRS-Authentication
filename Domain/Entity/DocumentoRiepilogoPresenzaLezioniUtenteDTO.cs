using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Business.GenerazioneDocumenti;

namespace WebAPI_CQRS.Domain.Entity
{
    public class DocumentoRiepilogoPresenzaLezioniUtenteDTO : EntityDTO
    {
        public Documento Documento { get; set; }
    }
}
