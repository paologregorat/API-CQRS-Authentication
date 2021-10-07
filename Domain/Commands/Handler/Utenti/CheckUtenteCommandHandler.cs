using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Utenti
{
    public class CheckUtenteCommandHandler : ICommandHandler<CheckUtenteCommand, CommandResponse>
    {
        private readonly CheckUtenteCommand _command;
        private readonly UtentiBusiness _business;
        public CheckUtenteCommandHandler(CheckUtenteCommand command, UtentiBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.CheckUtente(_command);
        }
    }
}
