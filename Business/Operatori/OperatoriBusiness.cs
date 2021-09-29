using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Authorization;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.Operatori
{
    public class OperatoriBusiness: IOperatoriBusiness
    {
        private SunshineContext _context;

        public OperatoriBusiness(SunshineContext context)
        {
            _context = context;
        }
        
        public Operatore GetUtente(string username, string password)
        {
            var entity = _context.Operatori.FirstOrDefault(c => c.UserName == username && c.Password == password);
            return entity;
        }

        public CommandResponse CreteToken(CreateTokenCommand command)
        {
            var response = new CommandResponse()
            {
                Success = false
            };
           
            var utente = GetUtente(command.UserName, command.Password);
            if (utente == default)
            {
                response.Success = false;
                response.Message = "Operatore non trovato.";
                return response;
            }
            
            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("grgpla74a26g284d"))
                .AddSubject(utente.Cognome)
                .AddIssuer("Fiver.Security.Bearer")
                .AddAudience("Fiver.Security.Bearer")
                .AddClaim("ID", utente.ID.ToString())
                .AddExpiry(1440)
                .Build();
            
            response.ID = utente.ID;
            response.Success = true;
            response.Message = token.Value;
            
            return response;
        }
    }
}
