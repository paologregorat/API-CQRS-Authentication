using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteDTO : EntityDTO
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string? ScadenzaCertificato { get; set; }
        public bool? TesseraPagata { get; set; }

        public UtenteDTO() {}
        public UtenteDTO(Utente utente)
        {
            ID = utente.ID;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            ScadenzaCertificato = utente.ScadenzaCertificato?.ToString("yyyy-MM-dd");
            TesseraPagata = utente.TesseraPagata;
        }
    }
}
