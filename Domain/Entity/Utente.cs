using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Utente : EntityBase
    {
        public Utente(Guid? id, string nome, string cognome,  DateTime? scadenzaCertificato, string tessera, bool? tesseraPagata,  string? note = default) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Note = note;
            Nome = nome;
            Cognome = cognome;
            TesseraPagata = tesseraPagata;
            Tessera = tessera;
            ScadenzaCertificato = scadenzaCertificato;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
        }

        private Utente()
        {
        }
        
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string? Tessera { get; set; }
        public string? Note { get; set; }
        
        public DateTime? ScadenzaCertificato { get; set; }
        public bool? TesseraPagata { get; set; }
        
        public IEnumerable<UtenteCorso> UtenteCorsi { get; }
        
        public IEnumerable<UtenteCalendarioCorso> UtenteCalendariCorsi { get; }

    }
}