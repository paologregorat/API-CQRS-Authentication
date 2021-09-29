using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Strutture
{
    public class StrutturaSerializer : IStrutturaSerializer
    {
        public List<StrutturaDTO> SerializeList(List<Struttura> toSerialize)
        {
            var result = new List<StrutturaDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new StrutturaDTO()
                {
                    ID = elem.ID,
                    Nome = elem.Nome,
                    Descrizione = elem.Descrizione,
                    Tipo = elem.Tipo
                };
                result.Add(serialized);
            }
            return result;
        }

        public  StrutturaDTO SerializeSingle(Struttura toSerialize)
        {
            var result = new StrutturaDTO()
            {
                ID = toSerialize.ID,
                Nome = toSerialize.Nome,
                Descrizione = toSerialize.Descrizione,
                Tipo = toSerialize.Tipo
            };
            return result;
        }
        
    }
}
