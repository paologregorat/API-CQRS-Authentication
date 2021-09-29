using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer.UtentiCorsi;

//using System.Data.Entity;

namespace WebAPI_CQRS.Business.UtentiCorsi
{
    public class UtentiCorsiBusiness: IUtentiCorsiBusiness
    {
        private UtenteCorsoSerializer _serializer;
        private SunshineContext _context;

        public UtentiCorsiBusiness(SunshineContext context, IUtenteCorsoSerializer serializer)
        {
            _serializer = (UtenteCorsoSerializer)serializer;
            _context = context;
        }
        public List<UtenteCorsoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.UtentiCorsi
                .Include(c => c.Corso)
                .Include(c => c.Utente)
                .ToList());
        }

        public UtenteCorsoDTO GetById(Guid id)
        {
            var entity = _context.UtentiCorsi.Where(c => c.ID == id)
                .Include(c => c.Corso)
                .Include(c => c.Utente)
                .FirstOrDefault();
            return _serializer.SerializeSingle(entity);
        }

        public UtenteCorsiDTO GetUtenteCorsi(Guid utenteID)
        {
            var utente = _context.Utenti.FirstOrDefault(u => u.ID == utenteID);
            var utenteCorsi = _context.UtentiCorsi.Where(u => u.UtenteID == utenteID)
                .Include(u => u.Corso).ToList();
            return _serializer.SerializeUtenteCorsi(utenteID, utente, utenteCorsi);
        }
        
        public UtentiCorsoDTO GetUtentiCorso(Guid corsoID)
        {
            var corso = _context.Corsi.FirstOrDefault(u => u.ID == corsoID);
            var utenteCorsi = _context.UtentiCorsi.Where(u => u.CorsoID == corsoID)
                .Include(u => u.Utente).ToList();
            return _serializer.SerializeUtentiCorso(corsoID, corso, utenteCorsi);
        }
        

        public CommandResponse Save(SaveUtenteCorsoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            var toUpdate = _context.UtentiCorsi.FirstOrDefault(e => e.ID == command.UtenteCorso.ID);
            if (toUpdate == default)
            {
                _context.UtentiCorsi.Add(command.UtenteCorso);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.UtenteCorso);
            }
            
            _context.SaveChanges();
            response.ID = command.UtenteCorso.ID;
            response.Success = true;
            response.Message = "UtenteCorso salvato.";
            
            return response;
        }
    }
}
