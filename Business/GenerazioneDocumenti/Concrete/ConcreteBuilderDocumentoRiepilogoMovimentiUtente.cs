using System;
using System.Linq;
using WebAPI_CQRS.Business.GenerazioneDocumenti.Abstract;
using WebAPI_CQRS.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_CQRS.Business.GenerazioneDocumenti.Concrete
{
    public class ConcreteBuilderDocumentoRiepilogoMovimentiUtente : IBuilderDocumento
    {
        private Documento  _documento = new Documento();

        private readonly Guid _utenteID;
        private readonly SunshineContext _context;

        public ConcreteBuilderDocumentoRiepilogoMovimentiUtente(SunshineContext context, Guid utenteId)
        {
            _context = context;
            _utenteID = utenteId;
        }
        public void BuidlDettaglio()
        {
            var movimenti = _context.Movimenti
                .Where(u => u.UtenteID == _utenteID);

            foreach (var movimento in movimenti)
            {
                var testo = "Movimento: " + movimento.Descrizione + " di data: " 
                            + movimento.Data.ToString("dd-MM-yyyy")
                            + " di importo: " + movimento.Importo.ToString();
                _documento.AddRigaDocumento(testo, 1);
            }
        }

        public void BuildTestata()
        {
            _documento.SetTestata("Riepilogo movimenhti");
        }

        public void BuildTotale()
        {
            _documento.CalcolaTotaleDocumento();
        }
        
        

        public Documento GetDocumentoIntero() => _documento;

    }
}