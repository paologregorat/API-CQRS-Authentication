using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Entity
{
    public class CommandResponse
    {
        public Guid ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
