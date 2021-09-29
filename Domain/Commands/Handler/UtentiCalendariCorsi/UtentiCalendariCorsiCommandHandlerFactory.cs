using WebAPI_CQRS.Business.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.UtentiCalendariCorsi;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.UtentiCalendariCorsi
{
    public static class UtenteCalendarioCorsoCommandHandlerFactory
    {
        public static ICommandHandler<SaveUtenteCalendarioCorsoCommand, CommandResponse> Build(SaveUtenteCalendarioCorsoCommand command, UtentiCalendariCorsiBusiness business)
        {
            return new SaveUtenteCalendarioCorsoCommandHandler(command, business);
        }
    }
}
