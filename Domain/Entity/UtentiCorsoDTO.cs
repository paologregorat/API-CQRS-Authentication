using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtentiCorsoDTO : EntityDTO
    {
        
        public Guid CorsoID { get; set; }

        public CorsoDTO Corso { get; set; }
        public List<UtenteDTO> Utenti { get; set; }
    }
}
