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
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure.Linq;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCalendariCorsi;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class UtentiCalendariCorsiController : WebControllerBase
    {
        private readonly UtentiCalendariCorsiBusiness _business;

        public UtentiCalendariCorsiController(IUtentiCalendariCorsiBusiness business)
        {
            _business = (UtentiCalendariCorsiBusiness)business;
        }

        [HttpGet]
        [Route("v1/utenticalendaricorsi")]
        public async Task<IActionResult> GetAll([FromQuery] RouteRequests.UtentiCalendariCorsiInfo request)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllUtentiCalendariCorsiQuery();
                var handler = UtenteCalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (List<UtenteCalendarioCorsoDTO>)  handler.Get();
                res = res.Filter(request).ToList();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
            
        }

        [HttpGet]
        [Route("v1/utenticalendaricorsi/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneUtenteCalendarioCorsoQuery(id);
                var handler = UtenteCalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtenteCalendarioCorsoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/utenticalendaricorsi")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var utenteID = (Guid) body.UtenteID;
                var calendarioCorsoID = (Guid)body.CalendarioCorsoID;
                UtenteCalendarioCorso item = new UtenteCalendarioCorso(id,utenteID, calendarioCorsoID);
                var command = new SaveUtenteCalendarioCorsoCommand(item);
          
                var handler = UtenteCalendarioCorsoCommandHandlerFactory.Build(command, _business);
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
        [Route("v1/utenticalendaricorsi")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var utenteID = (Guid) body.UtenteID;
                var calendarioCorsoID = (Guid)body.CalendarioCorsoID;
                UtenteCalendarioCorso item = new UtenteCalendarioCorso(id,utenteID, calendarioCorsoID);
                var command = new SaveUtenteCalendarioCorsoCommand(item);
          
                var handler = UtenteCalendarioCorsoCommandHandlerFactory.Build(command, _business);
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
        
        [HttpGet]
        [Route("v1/utenticalendaricorsi/{id}/utentecalendaricorsi")]
        public async Task<IActionResult> GetUtenteCalendariCorsi(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new UtenteCalendariCorsiQuery(id);
                var handler = UtenteCalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtenteCalendariCorsiDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
        
        [HttpGet]
        [Route("v1/utenticalendaricorsi/{id}/utenticalendariocorso")]
        public async Task<IActionResult> GetUtentiCalendarioCorso(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new UtentiCalendarioCorsoQuery(id);
                var handler = UtenteCalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtentiCalendarioCorsoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}
