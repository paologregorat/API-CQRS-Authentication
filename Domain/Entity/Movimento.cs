using System;
using System.Collections.Generic;
using WebAPI_CQRS.Business.GenerazioneDocumenti;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Movimento : EntityBase
    {
        public Movimento(Guid? id, Guid tipoMovimentoID, string descrizione, Guid? utenteID, Guid? personaleID, DateTime data, double? importo = 0 ) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            TipoMovimentoID = tipoMovimentoID;
            UtenteID = utenteID;
            PersonaleID = personaleID;
            Importo = importo;
            Data = data;
        }

        private Movimento()
        {
        }
        public string Descrizione { get; set; }
        public Guid TipoMovimentoID { get; set; }
        public TipoMovimento TipoMovimento { get; }
        public double? Importo { get; set; }
        public Guid? UtenteID { get; set; }
        public Guid? PersonaleID { get; set; }
        public DateTime Data { get; set; }
        public Personale Personale { get; }
        public Utente Utente { get; }

    }
}