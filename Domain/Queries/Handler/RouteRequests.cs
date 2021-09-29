using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WebAPI_CQRS.Domain.Infrastructure.Linq;

namespace WebAPI_CQRS.Domain.Queries.Handler
{
    public abstract class RouteRequests
    {
        public class UtentiInfo 
        {
            
           [Filter(Type = FilterTypeEnum.StringEqual)]
           public string? Nome { get; set; }
           
           [FilterAttribute(Type = FilterTypeEnum.StringEqual)]
           public string? Cognome { get; set; }
           
           public DateTime? ScadenzaCertificato { get; set; }
        }
        
        public class UtentiCorsiInfo 
        {
            
            [Filter(Type = FilterTypeEnum.GuidEqual)]
            public Guid? CorsoID { get; set; }
           
            [FilterAttribute(Type = FilterTypeEnum.GuidEqual)]
            public Guid? UtenteID { get; set; }
        }
        
        public class UtentiCalendariCorsiInfo 
        {
            
            [Filter(Type = FilterTypeEnum.GuidEqual)]
            public Guid? CalendarioCorsoID { get; set; }
           
            [FilterAttribute(Type = FilterTypeEnum.GuidEqual)]
            public Guid? UtenteID { get; set; }
        }
    }
}
