using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace WebAPI_CQRS.Domain.Entity
{
    public class TipoMovimento : EntityBase
    {
        public TipoMovimento(Guid? id, string entrataUscita, string tipo, string? descrizione) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            Tipo = tipo;
            EntrataUscita = entrataUscita;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private TipoMovimento()
        {
        }
        
        public string Tipo { get; set; }
        public string? Descrizione { get; set; }
        
        public string EntrataUscita { get; set; }
           
        [JsonIgnore] 
        public IEnumerable<Movimento> Movimenti { get; }

    }
}