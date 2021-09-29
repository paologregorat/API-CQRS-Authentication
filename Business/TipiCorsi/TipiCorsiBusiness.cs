using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer.Corsi;
using WebAPI_CQRS.Domain.Queries.Serializer.TipiCorsi;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.TipiCorsi
{
    public class TipiCorsiBusiness: ITipiCorsiBusiness
    {
        private TipoCorsoSerializer _serializer;
        private SunshineContext _context;

        public TipiCorsiBusiness(SunshineContext context, ITipoCorsoSerializer serializer)
        {
            _serializer = (TipoCorsoSerializer)serializer;
            _context = context;
        }
        public List<TipoCorsoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.TipiCorsi.ToList());
        }

        public TipoCorsoDTO GetById(Guid id)
        {
            var entity = _context.TipiCorsi.FirstOrDefault(c => c.ID == id);
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveTipoCorsoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            var toUpdate = _context.TipiCorsi.FirstOrDefault(e => e.ID == command.TipoCorso.ID);
            if (toUpdate == default)
            {
                _context.TipiCorsi.Add(command.TipoCorso);
            } else {
                _context.Entry(toUpdate).CurrentValues.SetValues(command.TipoCorso);
            }
            _context.SaveChanges();
            response.ID = command.TipoCorso.ID;
            response.Success = true;
            response.Message = "Tipo corso salvato.";
           
            return response;
        }
    }
}
