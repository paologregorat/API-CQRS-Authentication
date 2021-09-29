using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class TipoMovimentoDTO : EntityDTO
    {
        public string Tipo { get; set; }
        public string EntrataUscita { get; set; }
        public string? Descrizione { get; set; }
        
        public TipoMovimentoDTO() {}
        public TipoMovimentoDTO(TipoMovimento tipoMovimento)
        {
            ID = tipoMovimento.ID;
            Tipo = tipoMovimento.Tipo;
            Descrizione = tipoMovimento.Descrizione;
        }
    }
}
