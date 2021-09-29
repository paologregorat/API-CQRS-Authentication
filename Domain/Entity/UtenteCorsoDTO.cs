using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteCorsoDTO : EntityDTO
    {
       
        public Guid CorsoID { get; set; }
        public Guid UtenteID { get; set; }

        public CorsoDTO Corso { get; set; }
        public UtenteDTO Utente { get; set; }
    }
}
