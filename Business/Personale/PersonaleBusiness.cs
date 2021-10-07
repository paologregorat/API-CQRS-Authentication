using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Commons;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.Personale
{
    public class PersonaleBusiness: IPersonaleBusiness
    {
        private PersonaleSerializer _serializer;
        private SunshineContext _context;

        public PersonaleBusiness(SunshineContext context, IPersonaleSerializer serializer)
        {
            _serializer = (PersonaleSerializer)serializer;
            _context = context;
        }
        public List<PersonaleDTO> GetAll()
        {
            return _serializer.SerializeList(_context.Personale.ToList());
        }

        public PersonaleDTO GetById(Guid id)
        {
            var entity = _context.Personale.FirstOrDefault(c => c.ID == id);
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SavePersonaleCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            if (Validator<Domain.Entity.Personale>.CheckEntity(e =>
            {
                if (string.IsNullOrEmpty(e.Cognome) ||
                    string.IsNullOrEmpty(e.Nome))
                {
                    return false;
                }

                return true;
            }, command.Personale) == false)
            {
                response.Success = false;
                response.Message ="Cognome e nome obbligatori";
                return response;
            }
            
            var toUpdate = _context.Personale.FirstOrDefault(e => e.ID == command.Personale.ID);
            if (toUpdate == default)
            {
                _context.Personale.Add(command.Personale);
            } else {
                _context.Entry(toUpdate).CurrentValues.SetValues(command.Personale);
            }
            _context.SaveChanges();
            response.ID = command.Personale.ID;
            response.Success = true;
            response.Message = "Personale salvato.";
            
            return response;
        }
    }
}
