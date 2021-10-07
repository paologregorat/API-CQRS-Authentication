using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Commons;
using WebAPI_CQRS.Domain.Queries.Serializer.Corsi;
using WebAPI_CQRS.Domain.Queries.Serializer.Strutture;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.Strutture
{
    public class StruttureBusiness: IStruttureBusiness
    {
        private StrutturaSerializer _serializer;
        private SunshineContext _context;

        public StruttureBusiness(SunshineContext context, IStrutturaSerializer serializer)
        {
            _serializer = (StrutturaSerializer)serializer;
            _context = context;
        }
        public List<StrutturaDTO> GetAll()
        {
            return _serializer.SerializeList(_context.Strutture.ToList());
        }

        public StrutturaDTO GetById(Guid id)
        {
            var entity = _context.Strutture.FirstOrDefault(c => c.ID == id);
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveStrutturaCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            if (Validator<Domain.Entity.Struttura>.CheckEntity(e =>
            {
                if (string.IsNullOrEmpty(e.Nome))
                {
                    return false;
                }

                return true;
            }, command.Struttura) == false)
            {
                response.Success = false;
                response.Message ="Nome obbligatorio";
                return response;
            }
            
            var toUpdate = _context.Strutture.FirstOrDefault(e => e.ID == command.Struttura.ID);
            if (toUpdate == default)
            {
                _context.Strutture.Add(command.Struttura);
            } else {
                _context.Entry(toUpdate).CurrentValues.SetValues(command.Struttura);
            }
            _context.SaveChanges();
            response.ID = command.Struttura.ID;
            response.Success = true;
            response.Message = "Struttura salvata.";
            
            return response;
        }
    }
}
