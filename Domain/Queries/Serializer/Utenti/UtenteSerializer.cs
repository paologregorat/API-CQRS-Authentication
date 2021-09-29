using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Utenti
{
    public class UtenteSerializer : IUtenteSerializer
    {
        public List<UtenteDTO> SerializeList(List<Utente> toSerialize)
        {
            var result = new List<UtenteDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new UtenteDTO()
                {
                    ID = elem.ID,
                    Nome = elem.Nome,
                    Cognome = elem.Cognome,
                    TesseraPagata = elem.TesseraPagata,
                    ScadenzaCertificato = elem.ScadenzaCertificato?.ToString("yyyy-MM-dd")
                };
                result.Add(serialized);
            }
            return result;
        }

        public UtenteDTO SerializeSingle(Utente toSerialize)
        {
            var result = new UtenteDTO()
            {
                ID = toSerialize.ID,
                Nome = toSerialize.Nome,
                Cognome = toSerialize.Cognome,
                TesseraPagata = toSerialize.TesseraPagata,
                ScadenzaCertificato = toSerialize.ScadenzaCertificato?.ToString("yyyy-MM-dd")
            };
            return result;
        }
        
    }
}
