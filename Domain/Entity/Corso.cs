using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Corso : EntityBase
    {
        public Corso(Guid? id, Guid tipoCorsoID, string nome, string? descrizione) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            Nome = nome;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            TipoCorsoID = tipoCorsoID;
        }

        private Corso()
        {
        }
        
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        public Guid TipoCorsoID { get; set; }
        public TipoCorso TipoCorso { get; }
        public IEnumerable<UtenteCorso> UtentiCorso { get; }
        public IEnumerable<CalendarioCorso> CalendarioCorso { get; }
        
    }
}