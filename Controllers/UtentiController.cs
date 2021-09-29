using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure.Linq;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class UtentiController : WebControllerBase
    {
        private readonly UtentiBusiness _business;

        public UtentiController(IUtentiBusiness business)
        {
            _business = (UtentiBusiness)business;
        }

        [HttpGet]
        [Route("v1/utenti")]
        public async Task<IActionResult> GetAll([FromQuery] RouteRequests.UtentiInfo request)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllUtentiQuery();
                var handler = UtenteQueryHandlerFactory.Build(query, _business);
                var res = (List<UtenteDTO>) handler.Get();
                res = res.Filter(request).ToList();
                if (request.ScadenzaCertificato != null)
                {
                    res = res.Where(r => r.ScadenzaCertificato == null || Convert.ToDateTime(r.ScadenzaCertificato) < request.ScadenzaCertificato.Value).ToList();
                }
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpGet]
        [Route("v1/utenti/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneUtenteQuery(id);
                var handler = UtenteQueryHandlerFactory.Build(query, _business);
                var res = (UtenteDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/utenti")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var nome = (string?) body.Nome;
                var cognome = (string?) body.Cognome;
                var note = (string?) body.Note;
                var scadenzaCertificato = (DateTime?) body.ScadenzaCertificato;
                var tesseraPagata = (bool?) body.TesseraPagata;
                Utente item = new Utente(id, nome, cognome,scadenzaCertificato, tesseraPagata,  note);
                var command = new SaveUtenteCommand(item);
          
                var handler = UtenteCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    item.ID = response.ID;
                    return Ok(item.ID);
                }
                // an example of what might have gone wrong
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(response.Message),
                    ReasonPhrase = "InternalServerError"
                };
                throw new Exception(message.ToString());
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
        
        [HttpPut]
        [Route("v1/utenti")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var nome = (string?) body.Nome;
                var cognome = (string?) body.Cognome;
                var note = (string?) body.Note;
                var scadenzaCertificato = (DateTime?) body.ScadenzaCertificato;
                var tesseraPagata = (bool?) body.TesseraPagata;
                Utente item = new Utente(id, nome, cognome,scadenzaCertificato, tesseraPagata,  note);
                var command = new SaveUtenteCommand(item);
          
                var handler = UtenteCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    item.ID = response.ID;
                    return Ok(item.ID);
                }
                // an example of what might have gone wrong
                var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(response.Message),
                    ReasonPhrase = "InternalServerError"
                };
                throw new Exception(message.ToString());
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}
