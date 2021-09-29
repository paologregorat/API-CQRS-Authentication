using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtentiCalendarioCorsoDTO : EntityDTO
    {
        
        public Guid CalendarioCorsoID { get; set; }

        public CalendarioCorsoDTO CalendarioCorso { get; set; }
        public List<UtenteDTO> Utenti { get; set; }
    }
}
