using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class MovimentoDTO : EntityDTO
    {
        public string Descrizione { get; set; }

        public Guid TipoMovimentoID { get; set; }
        public TipoMovimentoDTO TipoMovimento { get; set; }
        
      
    }
}
