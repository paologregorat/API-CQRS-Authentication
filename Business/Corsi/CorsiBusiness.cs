using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer;
using WebAPI_CQRS.Domain.Queries.Serializer.Corsi;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;
//using System.Data.Entity;

namespace WebAPI_CQRS.Business.Corsi
{
    public class CorsiBusiness: ICorsiBusiness
    {
        private CorsoSerializer _serializer;
        private SunshineContext _context;

        public CorsiBusiness(SunshineContext context, ICorsoSerializer serializer)
        {
            _serializer = (CorsoSerializer)serializer;
            _context = context;
        }
        public List<CorsoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.Corsi
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .ToList());
        }

        public CorsoDTO GetById(Guid id)
        {
            var entity = _context.Corsi.Where(c => c.ID == id)
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Corso)
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Personale)
                .Include(c => c.TipoCorso)
                .Include(c => c.CalendarioCorso)
                .ThenInclude(c => c.Struttura)
                .FirstOrDefault();
            
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveCorsoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            var toUpdate = _context.Corsi.FirstOrDefault(e => e.ID == command.Corso.ID);
            if (toUpdate == default)
            {
                _context.Corsi.Add(command.Corso);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.Corso);
            }
            
            _context.SaveChanges();
            response.ID = command.Corso.ID;
            response.Success = true;
            response.Message = "Corso salvato.";
            
            return response;
        }
    }
}
