using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Queries.Serializer.Movimenti;
using WebAPI_CQRS.Infrastructure.Event;

//using System.Data.Entity;

namespace WebAPI_CQRS.Business.Movimenti
{
    public class MovimentiBusiness: IMovimentiBusiness
    {
        private MovimentoSerializer _serializer;
        private SunshineContext _context;

        public MovimentiBusiness(SunshineContext context, IMovimentoSerializer serializer)
        {
            _serializer = (MovimentoSerializer)serializer;
            _context = context;
        }
        public List<MovimentoDTO> GetAll()
        {
            return _serializer.SerializeList(_context.Movimenti.Include(c => c.TipoMovimento).ToList());
        }

        public MovimentoDTO GetById(Guid id)
        {
            var entity = _context.Movimenti.Where(c => c.ID == id).Include(c => c.TipoMovimento).FirstOrDefault();
            return _serializer.SerializeSingle(entity);
        }

        public CommandResponse Save(SaveMovimentoCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
            
            var toUpdate = _context.Movimenti.FirstOrDefault(e => e.ID == command.Movimento.ID);
            if (toUpdate == default)
            {
                _context.Movimenti.Add(command.Movimento);
            } else {
                
                _context.Entry(toUpdate).CurrentValues.SetValues(command.Movimento);
            }
            
            _context.SaveChanges();
            response.ID = command.Movimento.ID;
            response.Success = true;
            response.Message = "Movimento salvato.";
            
            return response;
        }
        
        //contabilizza partecipazione al corso
        public static void ContabilizzaPartecipazioneCorso(object source, UtentiEventHandler.MyEventArgs e)
        {
            var utente = e.GetInfo();
            var context = e.GetContext();
            Console.WriteLine("ContabilizzaPartecipazioneCorso eseguita");
        }
        
    }
}
