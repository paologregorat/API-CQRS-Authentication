using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCorsi;

namespace WebAPI_CQRS.Domain.Queries.Serializer.UtentiCorsi
{
    public class UtenteCorsoSerializer : IUtenteCorsoSerializer
    {
        public List<UtenteCorsoDTO> SerializeList(List<UtenteCorso> toSerialize)
        {
            var result = new List<UtenteCorsoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new UtenteCorsoDTO()
                {
                    ID = elem.ID,
                    UtenteID = elem.UtenteID,
                    CorsoID = elem.CorsoID,
                    Utente = new UtenteDTO(elem.Utente),
                    Corso = new CorsoDTO(elem.Corso) 
                };
                result.Add(serialized);
            }
            return result;
        }

        public  UtenteCorsoDTO SerializeSingle(UtenteCorso toSerialize)
        {
            var result = new UtenteCorsoDTO()
            {
                ID = toSerialize.ID,
                UtenteID = toSerialize.UtenteID,
                CorsoID = toSerialize.CorsoID,
                Utente = new UtenteDTO(toSerialize.Utente),
                Corso = new CorsoDTO(toSerialize.Corso) 
            };
            return result;
        }

        public UtenteCorsiDTO SerializeUtenteCorsi(Guid utenteID, Utente utente, IEnumerable<UtenteCorso> utenteCorsi)
        {
            var result = new UtenteCorsiDTO();
            result.ID = utenteID;
            result.UtenteID = utenteID;
            result.Utente = new UtenteDTO(utente);
            result.Corsi = new List<CorsoDTO>();
            foreach (var utenteCorso in utenteCorsi)
            {
                result.Corsi.Add(new CorsoDTO(utenteCorso.Corso));
            }

            return result;
        }
        
        public UtentiCorsoDTO SerializeUtentiCorso(Guid corsoID, Corso corso, IEnumerable<UtenteCorso> utentiCorso)
        {
            var result = new UtentiCorsoDTO();
            result.ID = corsoID;
            result.CorsoID = corsoID;
            result.Corso = new CorsoDTO(corso);
            result.Utenti = new List<UtenteDTO>();
            foreach (var utenteCorso in utentiCorso)
            {
                result.Utenti.Add(new UtenteDTO(utenteCorso.Utente));
            }

            return result;
        }
        
    }
}
