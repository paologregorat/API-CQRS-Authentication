using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Commons;
using WebAPI_CQRS.Domain.Queries.Serializer.CalendariCorsi;

//using System.Data.Entity;

namespace WebAPI_CQRS.Business.CalendariCorsi
{
    public class CalendariCorsiBusiness: ICalendariCorsiBusiness
    {
        private CalendarioCorsoSerializer _serializer;
        private SunshineContext _context;

        public CalendariCorsiBusiness(SunshineContext context, ICalendarioCorsoSerializer serializer)
        {
            _serializer = (CalendarioCorsoSerializer)serializer;
            _context = context;
        }
        public List<CalendarioCorsoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.CalendariCorsi
                .Include(c => c.Corso)
                .Include(c => c.Personale)
                .Include(c => c.Struttura)
                .ToList());
        }

        public CalendarioCorsoDTO GetById(Guid id)
        {
            var entity = _context.CalendariCorsi.Where(c => c.ID == id)
                .Include(c => c.Corso)
                .Include(c => c.Personale)
                .Include(c => c.Struttura)
                .FirstOrDefault();
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveCalendarioCorsoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            if (Validator<CalendarioCorso>.CheckEntity(e =>
            {
                if (e.PersonaleID == null ||
                    e.CorsoID == null)
                {
                    return false;
                }

                return true;
            }, command.CalendarioCorso) == false)
            {
                response.Success = false;
                response.Message ="CorsoID e PersonaleID obbligatori";
                return response;
            }
            
            var toUpdate = _context.CalendariCorsi.FirstOrDefault(e => e.ID == command.CalendarioCorso.ID);
            if (toUpdate == default)
            {
                _context.CalendariCorsi.Add(command.CalendarioCorso);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.CalendarioCorso);
            }
            
            _context.SaveChanges();
            response.ID = command.CalendarioCorso.ID;
            response.Success = true;
            response.Message = "CalendarioCorso salvato.";
            
            return response;
        }
    }
}
