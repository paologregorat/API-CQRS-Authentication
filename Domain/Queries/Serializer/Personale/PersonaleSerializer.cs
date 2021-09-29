using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Utenti
{
    public class PersonaleSerializer : IPersonaleSerializer
    {
        public List<PersonaleDTO> SerializeList(List<Personale> toSerialize)
        {
            var result = new List<PersonaleDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new PersonaleDTO()
                {
                    ID = elem.ID,
                    Nome = elem.Nome,
                    Cognome = elem.Cognome
                };
                result.Add(serialized);
            }
            return result;
        }

        public PersonaleDTO SerializeSingle(Personale toSerialize)
        {
            var result = new PersonaleDTO()
            {
                ID = toSerialize.ID,
                Nome = toSerialize.Nome,
                Cognome = toSerialize.Cognome
            };
            return result;
        }
        
    }
}
