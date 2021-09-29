using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Command
{
    public class SaveStrutturaCommand : ICommand<CommandResponse>
    {
        public Struttura Struttura { get; private set; }
        public SaveStrutturaCommand(Struttura item)
        {
            Struttura = item;
        }
    }
}
