using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebAPI_CQRS.Domain.Entity
{
    public class TipoCorso : EntityBase
    {
        public TipoCorso(Guid? id,  string tipo, string? descrizione) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            Tipo = tipo;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private TipoCorso()
        {
        }
        
        public string Tipo { get; set; }
        public string? Descrizione { get; set; }
        
        [JsonIgnore] 
        public IEnumerable<Corso> Corsi { get; }

    }
}