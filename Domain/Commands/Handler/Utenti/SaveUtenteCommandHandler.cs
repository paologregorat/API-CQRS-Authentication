using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Utenti
{
    public class SaveUtenteCommandHandler : ICommandHandler<SaveUtenteCommand, CommandResponse>
    {
        private readonly SaveUtenteCommand _command;
        private readonly UtentiBusiness _business;
        public SaveUtenteCommandHandler(SaveUtenteCommand command, UtentiBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.Save(_command);
        }
    }
}
