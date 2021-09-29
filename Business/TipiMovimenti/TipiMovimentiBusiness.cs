using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer.TipiMovimenti;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.TipiMovimenti
{
    public class TipiMovimentiBusiness: ITipiMovimentiBusiness
    {
        private TipoMovimentoSerializer _serializer;
        private SunshineContext _context;

        public TipiMovimentiBusiness(SunshineContext context, ITipoMovimentoSerializer serializer)
        {
            _serializer = (TipoMovimentoSerializer)serializer;
            _context = context;
        }
        public List<TipoMovimentoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.TipiMovimenti.ToList());
        }

        public TipoMovimentoDTO GetById(Guid id)
        {
            var entity = _context.TipiMovimenti.FirstOrDefault(c => c.ID == id);
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveTipoMovimentoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
           
            var toUpdate = _context.TipiMovimenti.FirstOrDefault(e => e.ID == command.TipoMovimento.ID);
            if (toUpdate == default)
            {
                _context.TipiMovimenti.Add(command.TipoMovimento);
            } else {
                _context.Entry(toUpdate).CurrentValues.SetValues(command.TipoMovimento);
            }
            _context.SaveChanges();
            response.ID = command.TipoMovimento.ID;
            response.Success = true;
            response.Message = "Tipo Movimento salvato.";
           
            return response;
        }
    }
}
