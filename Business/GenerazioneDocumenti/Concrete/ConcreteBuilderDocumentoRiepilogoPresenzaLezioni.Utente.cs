using System;
using System.Linq;
using WebAPI_CQRS.Business.GenerazioneDocumenti.Abstract;
using WebAPI_CQRS.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_CQRS.Business.GenerazioneDocumenti.Concrete
{
    public class ConcreteBuilderDocumentoRiepilogoPresenzaLezioniUtente : IBuilderDocumento
    {
        private Documento  _documento = new Documento();

        private readonly Guid _utenteID;
        private readonly SunshineContext _context;

        public ConcreteBuilderDocumentoRiepilogoPresenzaLezioniUtente(SunshineContext context, Guid utenteId)
        {
            _context = context;
            _utenteID = utenteId;
        }
        public void BuidlDettaglio()
        {
            var lezioni = _context.UtentiCalendariCorsi
                .Include(u => u.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Where(u => u.UtenteID == _utenteID);

            foreach (var lezione in lezioni)
            {
                var testo = "Lezione del corso: " + lezione.CalendarioCorso.Corso.Descrizione + " di data: " + lezione.CalendarioCorso.Data.ToString("dd-MM-yyyy");
                _documento.AddRigaDocumento(testo, 1);
            }
        }

        public void BuildTestata()
        {
            _documento.SetTestata("Riepilogo presenze lezioni");
        }

        public void BuildTotale()
        {
            _documento.CalcolaTotaleDocumento();
        }
        
        

        public Documento GetDocumentoIntero() => _documento;

    }
}