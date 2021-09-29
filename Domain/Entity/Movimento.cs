using System;
using System.Collections.Generic;

namespace WebAPI_CQRS.Domain.Entity
{
    public class Movimento : EntityBase
    {
        public Movimento(Guid? id, Guid tipoMovimentoID, string descrizione) : this()
        {
            ID = (id != null ? id : Guid.NewGuid()).Value;
            Descrizione = descrizione;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            TipoMovimentoID = tipoMovimentoID;
        }

        private Movimento()
        {
        }
        public string Descrizione { get; set; }
        public Guid TipoMovimentoID { get; set; }
        public TipoMovimento TipoMovimento { get; }

    }
}