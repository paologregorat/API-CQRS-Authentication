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
using WebAPI_CQRS.Business.Documenti;
using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Commands.Handler.Movimenti;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.Documenti;
using WebAPI_CQRS.Domain.Queries.Handler.Movimenti;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Documenti;
using WebAPI_CQRS.Domain.Queries.Query.Movimenti;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    [Authorize] 
    [Route("")]
    public class DocumentiController : WebControllerBase
    {
        private readonly DocumentiBusiness _business;

        public DocumentiController(IDocumentiBusiness business)
        {
            _business = (DocumentiBusiness)business;
        }

        [HttpGet]
        [Route("v1/documento-riepilogo-presenza-lezioni-utente/id")]
        public async Task<IActionResult> GetRiepilogoPresenzaLezioniUtente(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new DocumentoRiepilogoPresenzaLezioniUtenteQuery(id);
                var handler = DocumentoRiepilogoPresenzaLezioniUtenteQueryHandlerFactory.Build(query, _business);
                var res = (DocumentoRiepilogoPresenzaLezioniUtenteDTO) handler.Get();
                return Ok(res);
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpGet]
        [Route("v1/documento-movimenti-utente/id")]
        public async Task<IActionResult> GetMovimentiUtente(Guid id)
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var query = new DocumentoMovimentiUtenteQuery(id);
                var handler = DocumentoMovimentiUtenteQueryHandlerFactory.Build(query, _business);
                var res = (DocumentoMovimentiUtenteDTO) handler.Get();
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
