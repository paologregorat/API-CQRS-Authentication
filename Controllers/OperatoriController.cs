using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using WebAPI_CQRS.Business.Abstract;
using WebAPI_CQRS.Business.Operatori;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;
using WebAPI_CQRS.Domain.Infrastructure.Authorization;
using WebAPI_CQRS.Domain.Queries.Handler;
using WebAPI_CQRS.Domain.Queries.Handler.Corsi;
using WebAPI_CQRS.Domain.Queries.Query;
using WebAPI_CQRS.Domain.Queries.Query.Corsi;
using WebAPI_CQRS.Domain.Queries.Query.Utenti;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    [Route("")]
    public class OperatoriController : WebControllerBase
    {
        private readonly OperatoriBusiness _business;
        public OperatoriController(IOperatoriBusiness business)
        {
            _business = (OperatoriBusiness) business;
        }
        
        [Route("v1/operatori/login")]
        [HttpPost]
        public IActionResult Logon()
        {
            var origin = string.Format("{0}.{1}", MethodBase.GetCurrentMethod()?.DeclaringType.FullName, MethodBase.GetCurrentMethod()?.Name);
            try
            {
                LogAccess(origin);
                var body = JsonBody().Result;
                var userName = (string) body.Username;
                var password = (string) body.Password;
            
                var command = new CreateTokenCommand(userName, password);
          
                var handler = OperatoreCommandHandlerFactory.Build(command, _business);
                var response = handler.Execute();
                if (response.Success)
                {
                    return Ok(response.Message);
                }

                throw new Exception("Login fallito");
            }
            catch (Exception e)
            {
                LogError(origin, e.Message + e.InnerException);
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [Route("v1/operatori/getlog")]
        [HttpGet]
        public async Task<IActionResult> GetLog()
        {
            var str = LoggerHelper.GetInsance().GetLogTxt();
            return Ok(str);
        }
        
    }
}
