using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteCalendarioCorsoDTO : EntityDTO
    {
       
        public Guid CalendarioCorsoID { get; set; }
        public Guid UtenteID { get; set; }

        public CalendarioCorsoDTO CalendarioCorso { get; set; }
        public UtenteDTO Utente { get; set; }
    }
}
