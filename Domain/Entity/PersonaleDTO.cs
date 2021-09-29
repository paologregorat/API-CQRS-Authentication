using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class PersonaleDTO : EntityDTO
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        
        public PersonaleDTO() {}

        public PersonaleDTO(Personale personale)
        {
            Nome = personale.Nome;
            Cognome = personale.Cognome;
        }

    }
}
