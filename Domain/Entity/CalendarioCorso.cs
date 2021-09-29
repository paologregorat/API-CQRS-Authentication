using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class CalendarioCorso : EntityBase
    {
        public CalendarioCorso(Guid? id, Guid corsoID, Guid personaleID, Guid strutturaID, DateTime data, string? descrizione) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            CorsoID = corsoID;
            PersonaleID = personaleID;
            StrutturaID = strutturaID;
            Data = data;
        }

        private CalendarioCorso()
        {
        }
        
        public Guid CorsoID { get; set; }
        public Guid PersonaleID { get; set; }
        public Guid StrutturaID { get; set; }
        public string? Descrizione { get; set; }
        public DateTime Data { get; set; }
       
        public Corso Corso { get; }
        public Personale Personale { get; }
        public Struttura Struttura { get; }
        
        public IEnumerable<UtenteCalendarioCorso> UtentiCalendarioCorso { get; }
    }
}