using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class TipoCorsoDTO : EntityDTO
    {
        public string Tipo { get; set; }
        public string? Descrizione { get; set; }

        public TipoCorsoDTO() {}
        public TipoCorsoDTO(TipoCorso tipocorso)
        {
            ID = tipocorso.ID;
            Tipo = tipocorso.Tipo;
            Descrizione = tipocorso.Descrizione;
        }

    }
}
