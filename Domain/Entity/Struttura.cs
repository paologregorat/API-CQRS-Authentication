using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Struttura : EntityBase
    {
        public Struttura(Guid? id, string nome, string? descrizione, string? tipo) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            Nome = nome;
            Tipo = tipo;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private Struttura()
        {
        }
        
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        public string? Tipo { get; set; }

        public IEnumerable<CalendarioCorso> CalendariCorsi { get; }
    }
}