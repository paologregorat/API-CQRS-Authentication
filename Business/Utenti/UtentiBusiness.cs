using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.Utenti
{
    public class UtentiBusiness: IUtentiBusiness
    {
        private UtenteSerializer _serializer;
        private SunshineContext _context;

        public UtentiBusiness(SunshineContext context, IUtenteSerializer serializer)
        {
            _serializer = (UtenteSerializer)serializer;
            _context = context;
        }
        public List<UtenteDTO> GetAll()
        {
            return _serializer.SerializeList(_context.Utenti.ToList());
        }

        public UtenteDTO GetById(Guid id)
        {
            var entity = _context.Utenti.FirstOrDefault(c => c.ID == id);
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveUtenteCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            var toUpdate = _context.Utenti.FirstOrDefault(e => e.ID == command.Utente.ID);
            if (toUpdate == default)
            {
                _context.Utenti.Add(command.Utente);
            } else {
                _context.Entry(toUpdate).CurrentValues.SetValues(command.Utente);
            }
            _context.SaveChanges();
            response.ID = command.Utente.ID;
            response.Success = true;
            response.Message = "Utente salvato.";
            
            return response;
        }
    }
}
