using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class CorsoDTO : EntityDTO
    {
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        public Guid TipoCorsoID { get; set; }

        public TipoCorsoDTO TipoCorso { get; set; }
        public List<CalendarioCorsoDTO> CalendarioCorso {get; set; }
        
        public CorsoDTO() {}
        public CorsoDTO(Corso corso)
        {
            ID = corso.ID;
            Descrizione = corso.Descrizione;
            TipoCorsoID = corso.TipoCorsoID;
        }
    }
}
