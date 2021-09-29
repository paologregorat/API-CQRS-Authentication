using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.UtentiCorsi
{
    public class SaveUtenteCorsoCommandHandler : ICommandHandler<SaveUtenteCorsoCommand, CommandResponse>
    {
        private readonly SaveUtenteCorsoCommand _command;
        private readonly UtentiCorsiBusiness _business;
        public SaveUtenteCorsoCommandHandler(SaveUtenteCorsoCommand command, UtentiCorsiBusiness business)
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
