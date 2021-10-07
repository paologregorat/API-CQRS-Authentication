using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure;
using WebAPI_CQRS.Domain.Infrastructure.Commons;
using WebAPI_CQRS.Domain.Queries.Serializer;
using WebAPI_CQRS.Domain.Queries.Serializer.Utenti;

namespace WebAPI_CQRS.Business.Utenti
{
    delegate bool CheckUtenteDelegate(Utente utente);
    public class UtentiBusiness: IUtentiBusiness
    {
        public static class CheckUtenteMethods
        {
            public static bool CheckTessera(Utente utente) => utente.TesseraPagata != null && utente.TesseraPagata.Value;

            public static bool CheckCertificato(Utente utente) => utente.ScadenzaCertificato != null && utente.ScadenzaCertificato.Value >= DateTime.Now;

            public static bool CheckAbbonamento(Utente utente) => true;
        }
        
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

            if (Validator<Utente>.CheckEntity(e =>
            {
                if (string.IsNullOrEmpty(e.Cognome) ||
                    string.IsNullOrEmpty(e.Nome))
                {
                    return false;
                }

                return true;
            }, command.Utente) == false)
            {
                response.Success = false;
                response.Message ="Cognome e nome sono obbligatori";
                return response;
            }
            
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

        public CommandResponse CheckUtente(CheckUtenteCommand command)
        {
            var response = new CommandResponse()
            {
                Success = true
            };

            var utente = _context.Utenti.FirstOrDefault(u => u.Tessera == command.Tessera);
            if (utente == default)
            {
                response.Success = false;
                response.Message = "Utente non trovato";
                return response;
            }
                
            CheckUtenteDelegate checkTessera = CheckUtenteMethods.CheckTessera;
            if (!checkTessera.Invoke(utente))
            {
                response.Success = false;
                response.Message += "Tessera non abilitata; ";
            }
            CheckUtenteDelegate checkAbbonamento = CheckUtenteMethods.CheckAbbonamento;
            if (!checkAbbonamento.Invoke(utente))
            {
                response.Success = false;
                response.Message += "Abonamento scaduto; ";
            }
            CheckUtenteDelegate checkCertificato = CheckUtenteMethods.CheckCertificato;
            if (!checkCertificato.Invoke(utente))
            {
                response.Success = false;
                response.Message += "Certificato scaduto; ";
            }

            return response;
        }
    }
    
    
}
