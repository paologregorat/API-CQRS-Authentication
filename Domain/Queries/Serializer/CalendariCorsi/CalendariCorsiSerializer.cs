using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Serializer.CalendariCorsi
{
    public class CalendarioCorsoSerializer : ICalendarioCorsoSerializer
    {
        public List<CalendarioCorsoDTO> SerializeList(List<CalendarioCorso> toSerialize)
        {
            var result = new List<CalendarioCorsoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new CalendarioCorsoDTO()
                {
                    ID = elem.ID,
                    Descrizione = elem.Descrizione,
                    CorsoID = elem.CorsoID,
                    PersonaleID = elem.PersonaleID,
                    StrutturaID = elem.StrutturaID,
                    Corso = new CorsoDTO(elem.Corso),
                    Personale = new PersonaleDTO(elem.Personale),
                    Struttura = new StrutturaDTO(elem.Struttura),
                    Data = elem.Data.ToString("yyyy-MM-dd")
                };
                result.Add(serialized);
            }
            return result;
        }

        public  CalendarioCorsoDTO SerializeSingle(CalendarioCorso toSerialize)
        {
            var result = new CalendarioCorsoDTO()
            {
                ID = toSerialize.ID,
                Descrizione = toSerialize.Descrizione,
                CorsoID = toSerialize.CorsoID,
                PersonaleID = toSerialize.PersonaleID,
                StrutturaID = toSerialize.StrutturaID,
                Corso = new CorsoDTO(toSerialize.Corso),
                Personale = new PersonaleDTO(toSerialize.Personale),
                Struttura = new StrutturaDTO(toSerialize.Struttura),
                Data = toSerialize.Data.ToString("yyyy-MM-dd")
            };
            return result;
        }
        
    }
}
