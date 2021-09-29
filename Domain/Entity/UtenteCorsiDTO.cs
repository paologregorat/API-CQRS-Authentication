using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class UtenteCorsiDTO : EntityDTO
    {
        
        public Guid UtenteID { get; set; }

        public UtenteDTO Utente { get; set; }
        public List<CorsoDTO> Corsi { get; set; }
    }
}
