using System.Collections.Generic;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Domain.Queries.Serializer.Movimenti
{
    public class MovimentoSerializer : IMovimentoSerializer
    {
        public List<MovimentoDTO> SerializeList(List<Movimento> toSerialize)
        {
            var result = new List<MovimentoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new MovimentoDTO()
                {
                    ID = elem.ID,
                    Descrizione = elem.Descrizione,
                    TipoMovimentoID = elem.TipoMovimentoID,
                    TipoMovimento = new TipoMovimentoDTO(elem.TipoMovimento) 
                };
                result.Add(serialized);
            }
            return result;
        }

        public  MovimentoDTO SerializeSingle(Movimento toSerialize)
        {
            var result = new MovimentoDTO()
            {
                ID = toSerialize.ID,
                Descrizione = toSerialize.Descrizione,
                TipoMovimentoID = toSerialize.TipoMovimentoID,
                TipoMovimento = new TipoMovimentoDTO(toSerialize.TipoMovimento) 
            };
            return result;
        }
        
    }
}
