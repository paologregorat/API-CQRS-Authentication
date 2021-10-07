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
using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure.Linq;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.UtentiCorsi;
using WebAPI_CQRS.Domain.Queries.Query.UtentiCorsi;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class UtentiCorsiController : WebControllerBase
    {
        private readonly UtentiCorsiBusiness _business;

        public UtentiCorsiController(IUtentiCorsiBusiness business)
        {
            _business = (UtentiCorsiBusiness)business;
        }

        [HttpGet]
        [Route("v1/utenticorsi")]
        public async Task<IActionResult> GetAll([FromQuery] RouteRequests.UtentiCorsiInfo request)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllUtentiCorsiQuery();
                var handler = UtenteCorsoQueryHandlerFactory.Build(query, _business);
                var res = (List<UtenteCorsoDTO>)  handler.Get();
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
        [Route("v1/utenticorsi/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneUtenteCorsoQuery(id);
                var handler = UtenteCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtenteCorsoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/utenticorsi")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var utenteID = (Guid) body.UtenteID;
                var corsoID = (Guid)body.CorsoID;
                UtenteCorso item = new UtenteCorso(id,utenteID, corsoID);
                var command = new SaveUtenteCorsoCommand(item);
          
                var handler = UtenteCorsoCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    item.ID = response.ID;
                    return Ok(item.ID);
                }
                throw new Exception(response.Message);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
        
        [HttpPut]
        [Route("v1/utenticorsi")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var utenteID = (Guid) body.UtenteID;
                var corsoID = (Guid)body.CorsoID;
                UtenteCorso item = new UtenteCorso(id,utenteID, corsoID);
                var command = new SaveUtenteCorsoCommand(item);
          
                var handler = UtenteCorsoCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    item.ID = response.ID;
                    return Ok(item.ID);
                }
                throw new Exception(response.Message);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
        
        [HttpGet]
        [Route("v1/utenticorsi/{id}/utentecorsi")]
        public async Task<IActionResult> GetUtenteCorsi(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new UtenteCorsiQuery(id);
                var handler = UtenteCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtenteCorsiDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }
        
        [HttpGet]
        [Route("v1/utenticorsi/{id}/utenticorso")]
        public async Task<IActionResult> GetUtentiCorso(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new UtentiCorsoQuery(id);
                var handler = UtenteCorsoQueryHandlerFactory.Build(query, _business);
                var res = (UtentiCorsoDTO) handler.Get();
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
