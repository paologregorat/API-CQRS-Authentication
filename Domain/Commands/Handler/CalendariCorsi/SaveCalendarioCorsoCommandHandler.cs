using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.CalendariCorsi
{
    public class SaveCalendarioCorsoCommandHandler : ICommandHandler<SaveCalendarioCorsoCommand, CommandResponse>
    {
        private readonly SaveCalendarioCorsoCommand _command;
        private readonly CalendariCorsiBusiness _business;
        public SaveCalendarioCorsoCommandHandler(SaveCalendarioCorsoCommand command, CalendariCorsiBusiness business)
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
