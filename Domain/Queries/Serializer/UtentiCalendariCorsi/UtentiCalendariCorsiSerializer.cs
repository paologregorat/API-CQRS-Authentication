using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Domain.Queries.Serializer.UtentiCalendariCorsi
{
    public class UtenteCalendarioCorsoSerializer : IUtenteCalendarioCorsoSerializer
    {
        public List<UtenteCalendarioCorsoDTO> SerializeList(List<UtenteCalendarioCorso> toSerialize)
        {
            var result = new List<UtenteCalendarioCorsoDTO>();
            foreach (var elem in toSerialize)
            {
                var serialized = new UtenteCalendarioCorsoDTO()
                {
                    ID = elem.ID,
                    UtenteID = elem.UtenteID,
                    CalendarioCorsoID = elem.CalendarioCorsoID,
                    Utente = new UtenteDTO(elem.Utente),
                    CalendarioCorso = new CalendarioCorsoDTO(elem.CalendarioCorso) 
                };
                result.Add(serialized);
            }
            return result;
        }

        public  UtenteCalendarioCorsoDTO SerializeSingle(UtenteCalendarioCorso toSerialize)
        {
            var result = new UtenteCalendarioCorsoDTO()
            {
                ID = toSerialize.ID,
                UtenteID = toSerialize.UtenteID,
                CalendarioCorsoID = toSerialize.CalendarioCorsoID,
                Utente = new UtenteDTO(toSerialize.Utente),
                CalendarioCorso = new CalendarioCorsoDTO(toSerialize.CalendarioCorso) 
            };
            return result;
        }

        public UtenteCalendariCorsiDTO SerializeUtenteCalendariCorsi(Guid utenteID, Utente utente, IEnumerable<UtenteCalendarioCorso> utenteCalendariCorsi)
        {
            var result = new UtenteCalendariCorsiDTO();
            result.ID = utenteID;
            result.UtenteID = utenteID;
            result.Utente = new UtenteDTO(utente);
            result.CalendariCorsi = new List<CalendarioCorsoDTO>();
            foreach (var utenteCalendarioCorso in utenteCalendariCorsi)
            {
                result.CalendariCorsi.Add(new CalendarioCorsoDTO(utenteCalendarioCorso.CalendarioCorso));
            }

            return result;
        }
        
        public UtentiCalendarioCorsoDTO SerializeUtentiCalendarioCorso(Guid calendarioCorsoID, CalendarioCorso CalendarioCorso, IEnumerable<UtenteCalendarioCorso> utentiCalendarioCorso)
        {
            var result = new UtentiCalendarioCorsoDTO();
            result.ID = calendarioCorsoID;
            result.CalendarioCorsoID = calendarioCorsoID;
            result.CalendarioCorso = new CalendarioCorsoDTO(CalendarioCorso);
            result.Utenti = new List<UtenteDTO>();
            foreach (var utenteCalendarioCorso in utentiCalendarioCorso)
            {
                result.Utenti.Add(new UtenteDTO(utenteCalendarioCorso.Utente));
            }

            return result;
        }
        
    }
}
