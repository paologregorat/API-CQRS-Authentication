using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class CalendarioCorsoDTO : EntityDTO
    {
        public Guid CorsoID { get; set; }
        public Guid PersonaleID { get; set; }
        public Guid StrutturaID { get; set; }
        public string? Descrizione { get; set; }
        public string Data { get; set; }
       
        public CorsoDTO Corso { get; set; }
        public PersonaleDTO Personale { get; set; }
        public StrutturaDTO Struttura { get; set; }

        public CalendarioCorsoDTO() {}

        public CalendarioCorsoDTO(CalendarioCorso calendarioCorso)
        {
            ID = calendarioCorso.ID;
            CorsoID = calendarioCorso.CorsoID;
            PersonaleID = calendarioCorso.PersonaleID;
            StrutturaID = calendarioCorso.StrutturaID;
            Descrizione = calendarioCorso.Descrizione;
            Data = calendarioCorso.Data.ToString("yyyy-MM-dd");
            Corso = new CorsoDTO(calendarioCorso.Corso);
            Personale = new PersonaleDTO(calendarioCorso.Personale);
            Struttura = new StrutturaDTO(calendarioCorso.Struttura);
        }
    }
}
