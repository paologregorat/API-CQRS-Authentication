using System;
using System.Collections.Generic;
using WebAPI_CQRS.Domain.Queries.Handler;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteCorso : EntityBase
    {
        public UtenteCorso(Guid? id, Guid utenteID, Guid corsoID) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            UtenteID = utenteID;
            CorsoID = corsoID;
        }

        private UtenteCorso()
        {
        }
        
        public Guid UtenteID { get; set; }
        public Guid CorsoID { get; set; }
        public Corso Corso { get; }
        public Utente Utente { get; }

    }
}