using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.UtentiCalendariCorsi
{
    public class SaveUtenteCalendarioCorsoCommandHandler : ICommandHandler<SaveUtenteCalendarioCorsoCommand, CommandResponse>
    {
        private readonly SaveUtenteCalendarioCorsoCommand _command;
        private readonly UtentiCalendariCorsiBusiness _business;
        public SaveUtenteCalendarioCorsoCommandHandler(SaveUtenteCalendarioCorsoCommand command, UtentiCalendariCorsiBusiness business)
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
