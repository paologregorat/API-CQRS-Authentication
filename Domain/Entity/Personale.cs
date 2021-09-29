using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Personale : EntityBase
    {
        public Personale(Guid? id, string nome, string cognome) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Nome = nome;
            Cognome = cognome;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private Personale()
        {
        }
        
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public IEnumerable<CalendarioCorso> CalendariCorsi { get; }
    }
}