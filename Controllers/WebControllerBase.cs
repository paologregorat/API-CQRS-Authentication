using System;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI_CQRS.Domain.Infrastructure.Utility;
using WebAPI_CQRS.Infrastructure;

namespace WebAPI_CQRS.Controllers
{
    public class WebControllerBase : ControllerBase
    {
        protected async Task<dynamic> JsonBody () {
            var result = await JsonDocument.ParseAsync (Request.Body);
            return new JsonDynamicObject {
                RealObject = result.RootElement
            };
        }

        protected void LogAccess(string origin)
        {
            var logger = LoggerHelper.GetInsance().GetLogger();
            string method = string.Format("{0} {1}", "Start: ",  origin); 
            logger.LogInformation(this.GetType().FullName + " - " + method);
        }
        
        protected void LogError(string origin, string error)
        {
            var logger = LoggerHelper.GetInsance().GetLogger();
            string method = string.Format("{0} {1} {2}", "Start: ",  origin, error); 
            logger.LogInformation(this.GetType().FullName + " - " + method);
        }
        
    }
}