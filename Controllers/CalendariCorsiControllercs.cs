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
using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Commands.Handler.CalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.CalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.CalendariCorsi;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class CalendariCorsiController : WebControllerBase
    {
        private readonly CalendariCorsiBusiness _business;

        public CalendariCorsiController(ICalendariCorsiBusiness business)
        {
            _business = (CalendariCorsiBusiness)business;
        }

        [HttpGet]
        [Route("v1/calendaricorsi")]
        public async Task<IActionResult> GetAll()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllCalendariCorsiQuery();
                var handler = CalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (List<CalendarioCorsoDTO>) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
            
        }

        [HttpGet]
        [Route("v1/calendaricorsi/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneCalendarioCorsoQuery(id);
                var handler = CalendarioCorsoQueryHandlerFactory.Build(query, _business);
                var res = (CalendarioCorsoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/calendaricorsi")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var descrizione = (string?) body.Descrizione;
                var personaleID = (Guid) body.PersonaleID;
                var corsoID = (Guid) body.CorsoID;
                var strutturaID = (Guid) body.StrutturaID;
                var data = (DateTime) body.Data;
                CalendarioCorso item = new CalendarioCorso(id,corsoID,personaleID,strutturaID, data, descrizione);
                var command = new SaveCalendarioCorsoCommand(item);
          
                var handler = CalendarioCorsoCommandHandlerFactory.Build(command, _business);
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
        [Route("v1/calendaricorsi")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var descrizione = (string?) body.Descrizione;
                var personaleID = (Guid) body.PersonaleID;
                var corsoID = (Guid) body.CorsoID;
                var strutturaID = (Guid) body.StrutturaID;
                var data = (DateTime) body.Data;
                CalendarioCorso item = new CalendarioCorso(id,corsoID,personaleID,strutturaID, data, descrizione);
                var command = new SaveCalendarioCorsoCommand(item);
          
                var handler = CalendarioCorsoCommandHandlerFactory.Build(command, _business);
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
