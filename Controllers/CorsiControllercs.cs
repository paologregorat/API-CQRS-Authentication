using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Commands.Handler.Corsi;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class CorsiController : WebControllerBase
    {
        private readonly CorsiBusiness _business;

        public CorsiController(ICorsiBusiness business)
        {
            _business = (CorsiBusiness)business;
        }

        [HttpGet]
        [Route("v1/corsi")]
        public async Task<IActionResult> GetAll()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllCorsiQuery();
                var handler = CorsoQueryHandlerFactory.Build(query, _business);
                var res = (List<CorsoDTO>) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
            
        }

        [HttpGet]
        [Route("v1/corsi/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneCorsoQuery(id);
                var handler = CorsoQueryHandlerFactory.Build(query, _business);
                var res = (CorsoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/corsi")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var nome = (string?) body.Nome;
                var descrizione = (string?) body.Descrizione;
                var tipoCorsoID = (Guid)body.TipoCorsoID;
                Corso item = new Corso(id,tipoCorsoID, nome, descrizione);
                var command = new SaveCorsoCommand(item);
          
                var handler = CorsoCommandHandlerFactory.Build(command, _business);
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
        [Route("v1/corsi")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var nome = (string?) body.Nome;
                var descrizione = (string?) body.Descrizione;
                var tipoCorsoID = (Guid)body.TipoCorsoID;
                Corso item = new Corso(id,tipoCorsoID, nome, descrizione);
                var command = new SaveCorsoCommand(item);
          
                var handler = CorsoCommandHandlerFactory.Build(command, _business);
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
