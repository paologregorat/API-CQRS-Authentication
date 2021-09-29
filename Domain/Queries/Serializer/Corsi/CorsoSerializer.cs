using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Corsi
{
    public class CorsoSerializer : ICorsoSerializer
    {
        public List<CorsoDTO> SerializeList(List<Corso> toSerialize)
        {
            var result = new List<CorsoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new CorsoDTO()
                {
                    ID = elem.ID,
                    Nome = elem.Nome,
                    Descrizione = elem.Descrizione,
                    TipoCorsoID = elem.TipoCorsoID,
                    TipoCorso = new TipoCorsoDTO(elem.TipoCorso),
                    CalendarioCorso = new List<CalendarioCorsoDTO>()
                };
                foreach (var calendario in elem.CalendarioCorso)
                {
                    serialized.CalendarioCorso.Add(new CalendarioCorsoDTO(calendario));
                }
                result.Add(serialized);
            }
            return result;
        }

        public  CorsoDTO SerializeSingle(Corso toSerialize)
        {
            var result = new CorsoDTO()
            {
                ID = toSerialize.ID,
                Nome = toSerialize.Nome,
                Descrizione = toSerialize.Descrizione,
                TipoCorsoID = toSerialize.TipoCorsoID,
                TipoCorso = new TipoCorsoDTO(toSerialize.TipoCorso),
                CalendarioCorso = new List<CalendarioCorsoDTO>()
            };
            foreach (var calendario in toSerialize.CalendarioCorso)
            {
                result.CalendarioCorso.Add(new CalendarioCorsoDTO(calendario));
            }
            return result;
        }
        
    }
}
