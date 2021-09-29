using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.TipiMovimenti
{
    public class TipoMovimentoSerializer : ITipoMovimentoSerializer
    {
        public List<TipoMovimentoDTO> SerializeList(List<TipoMovimento> toSerialize)
        {
            var result = new List<TipoMovimentoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new TipoMovimentoDTO()
                {
                    ID = elem.ID,
                    Tipo = elem.Tipo,
                    Descrizione = elem.Descrizione,
                    EntrataUscita = elem.EntrataUscita
                };
                result.Add(serialized);
            }
            return result;
        }

        public  TipoMovimentoDTO SerializeSingle(TipoMovimento toSerialize)
        {
            var result = new TipoMovimentoDTO()
            {
                ID = toSerialize.ID,
                Tipo = toSerialize.Tipo,
                Descrizione = toSerialize.Descrizione,
                EntrataUscita = toSerialize.EntrataUscita
            };
            return result;
        }
        
    }
}
