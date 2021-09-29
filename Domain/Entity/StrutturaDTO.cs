using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class StrutturaDTO : EntityDTO
    {
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        public string? Tipo { get; set; }
        public StrutturaDTO() {}

        public StrutturaDTO(Struttura struttura)
        {
            Nome = struttura.Nome;
            Descrizione = struttura.Descrizione;
            Tipo = struttura.Tipo;
        }
    }
}
