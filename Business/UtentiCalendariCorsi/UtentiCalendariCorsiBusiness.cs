using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCalendariCorsi;
using WebAPI_CQRS.Infrastructure.Event;

//using System.Data.Entity;

namespace WebAPI_CQRS.Business.UtentiCalendariCorsi
{
    public class UtentiCalendariCorsiBusiness: IUtentiCalendariCorsiBusiness
    {
        public event UtentiEventHandler.MyUtenteEventHandler OnUtentePartecipaAlCorso;
        
        private UtenteCalendarioCorsoSerializer _serializer;
        private SunshineContext _context;

        public UtentiCalendariCorsiBusiness() {}
        public UtentiCalendariCorsiBusiness(SunshineContext context, IUtenteCalendarioCorsoSerializer serializer)
        {
            _serializer = (UtenteCalendarioCorsoSerializer)serializer;
            _context = context;
        }
        public List<UtenteCalendarioCorsoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.UtentiCalendariCorsi
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.Utente)
                .ToList());
        }

        public UtenteCalendarioCorsoDTO GetById(Guid id)
        {
            var entity = _context.UtentiCalendariCorsi.Where(c => c.ID == id)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.Utente)
                .FirstOrDefault();
            return _serializer.SerializeSingle(entity);
        }

        public UtenteCalendariCorsiDTO GetUtenteCalendariCorsi(Guid utenteID)
        {
            var utente = _context.Utenti.FirstOrDefault(u => u.ID == utenteID);
            var utenteCalendariCorsi = _context.UtentiCalendariCorsi
                .Where(u => u.UtenteID == utenteID)
                .Include(u => u.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.Utente)
                .ToList();
            return _serializer.SerializeUtenteCalendariCorsi(utenteID, utente, utenteCalendariCorsi);
        }
        
        public UtentiCalendarioCorsoDTO GetUtentiCalendarioCorso(Guid calendarioCorsoID)
        {
            var CalendarioCorso = _context.CalendariCorsi.FirstOrDefault(u => u.ID == calendarioCorsoID);
            var utenteCalendariCorsi = _context.UtentiCalendariCorsi
                .Include(u => u.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.Utente)
                .Where(u => u.CalendarioCorsoID == calendarioCorsoID)
                .Include(u => u.Utente)
                .ToList();
            return _serializer.SerializeUtentiCalendarioCorso(calendarioCorsoID, CalendarioCorso, utenteCalendariCorsi);
        }
        

        public CommandResponse Save(SaveUtenteCalendarioCorsoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            var toUpdate = _context.UtentiCalendariCorsi.FirstOrDefault(e => e.ID == command.UtenteCalendarioCorso.ID);
            if (toUpdate == default)
            {
                _context.UtentiCalendariCorsi.Add(command.UtenteCalendarioCorso);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.UtenteCalendarioCorso);
            }
            
            _context.SaveChanges();
            response.ID = command.UtenteCalendarioCorso.ID;
            response.Success = true;
            response.Message = "UtenteCalendarioCorso salvato.";

            Utente toEvent = command.UtenteCalendarioCorso.Utente;
            if (toEvent == null)
                toEvent = _context.Utenti.FirstOrDefault(u => u.ID == command.UtenteCalendarioCorso.UtenteID);
            var onUtentePartecipaAlCorso = EventsHandler.GetInstance()._ucc.OnUtentePartecipaAlCorso;
            if (onUtentePartecipaAlCorso != null)
                onUtentePartecipaAlCorso(this,new UtentiEventHandler.MyEventArgs(_context, toEvent));            
            
            return response;
        }
    }
}
