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
using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.TipiMovimenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler.TipiMovimenti;
using WebAPI_CQRS.Domain.Queries.Query.TipiMovimenti;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class TipiMovimentiController : WebControllerBase
    {
        private readonly TipiMovimentiBusiness _business;

        public TipiMovimentiController(ITipiMovimentiBusiness business)
        {
            _business = (TipiMovimentiBusiness)business;
        }

        [HttpGet]
        [Route("v1/tipiMovimenti")]
        public async Task<IActionResult> GetAll()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new AllTipiMovimentiQuery();
                var handler = TipoMovimentoQueryHandlerFactory.Build(query, _business);
                var res = (List<TipoMovimentoDTO>) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
            
        }

        [HttpGet]
        [Route("v1/tipiMovimenti/{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new OneTipoMovimentoQuery(id);
                var handler = TipoMovimentoQueryHandlerFactory.Build(query, _business);
                var res = (TipoMovimentoDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("v1/tipiMovimenti")]
        public async Task<IActionResult> Post()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var tipo = (string) body.Tipo;
                var entrataUscita = (string) body.EntrataUscita;
                var descrizione = (string?) body.Descrizione;
                TipoMovimento item = new TipoMovimento(id,entrataUscita, tipo, descrizione);
                var command = new SaveTipoMovimentoCommand(item);
          
                var handler = TipoMovimentoCommandHandlerFactory.Build(command, _business);
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
        [Route("v1/tipiMovimenti")]
        public async Task<IActionResult> Put()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var id = (Guid?) body.ID; 
                var tipo = (string) body.Tipo;
                var entrataUscita = (string) body.EntrataUscita;
                var descrizione = (string?) body.Descrizione;
                TipoMovimento item = new TipoMovimento(id, entrataUscita, tipo, descrizione);
                var command = new SaveTipoMovimentoCommand(item);
          
                var handler = TipoMovimentoCommandHandlerFactory.Build(command, _business);
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
