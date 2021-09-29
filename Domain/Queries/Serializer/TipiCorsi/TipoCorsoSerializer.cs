using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.TipiCorsi
{
    public class TipoCorsoSerializer : ITipoCorsoSerializer
    {
        public List<TipoCorsoDTO> SerializeList(List<TipoCorso> toSerialize)
        {
            var result = new List<TipoCorsoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new TipoCorsoDTO()
                {
                    ID = elem.ID,
                    Tipo = elem.Tipo,
                    Descrizione = elem.Descrizione
                };
                result.Add(serialized);
            }
            return result;
        }

        public  TipoCorsoDTO SerializeSingle(TipoCorso toSerialize)
        {
            var result = new TipoCorsoDTO()
            {
                ID = toSerialize.ID,
                Tipo = toSerialize.Tipo,
                Descrizione = toSerialize.Descrizione
            };
            return result;
        }
        
    }
}
