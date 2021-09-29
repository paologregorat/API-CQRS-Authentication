using WebAPI_CQRS.Business.CalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.CalendariCorsi
{
    public static class CalendarioCorsoCommandHandlerFactory
    {
        public static ICommandHandler<SaveCalendarioCorsoCommand, CommandResponse> Build(SaveCalendarioCorsoCommand command, CalendariCorsiBusiness business)
        {
            return new SaveCalendarioCorsoCommandHandler(command, business);
        }
    }
}
