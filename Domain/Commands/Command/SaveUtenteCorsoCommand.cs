using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Command
{
    public class SaveUtenteCorsoCommand : ICommand<CommandResponse>
    {
        public UtenteCorso UtenteCorso { get; private set; }
        public SaveUtenteCorsoCommand(UtenteCorso item)
        {
            UtenteCorso = item;
        }
    }
}
