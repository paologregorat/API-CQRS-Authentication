using System;
using System.Collections.Generic;
using WebAPI_CQRS.Domain.Queries.Handler;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteCalendarioCorso : EntityBase
    {
        public UtenteCalendarioCorso(Guid? id, Guid utenteID, Guid calendarioCorsoID) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            UtenteID = utenteID;
            CalendarioCorsoID = calendarioCorsoID;
        }

        private UtenteCalendarioCorso()
        {
        }
        
        public Guid UtenteID { get; set; }
        public Guid CalendarioCorsoID { get; set; }
        public CalendarioCorso CalendarioCorso { get; }
        public Utente Utente { get; }

    }
}