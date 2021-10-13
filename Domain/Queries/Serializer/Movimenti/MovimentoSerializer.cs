using System.Collections.Generic;
using System.Dynamic;
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
                    TipoMovimento = new TipoMovimentoDTO(elem.TipoMovimento) ,
                    Personale = elem.Personale?.Cognome + " " + elem.Personale?.Nome,
                    Utente = elem.Utente?.Cognome + " " + elem.Personale?.Nome,
                    Data = elem.Data.ToString("dd-MM-yyyy"),
                    Importo =  elem.Importo
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
                TipoMovimento = new TipoMovimentoDTO(toSerialize.TipoMovimento),
                Personale = toSerialize.Personale?.Cognome + " " + toSerialize.Personale?.Nome,
                Utente = toSerialize.Utente?.Cognome + " " + toSerialize.Personale?.Nome,
                Data = toSerialize.Data.ToString("dd-MM-yyyy"),
                Importo =  toSerialize.Importo
            };
            return result;
        }
        
    }
}
