using WebAPI_CQRS.Business.UtentiCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.UtentiCorsi;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.UtentiCorsi
{
    public static class UtenteCorsoCommandHandlerFactory
    {
        public static ICommandHandler<SaveUtenteCorsoCommand, CommandResponse> Build(SaveUtenteCorsoCommand command, UtentiCorsiBusiness business)
        {
            return new SaveUtenteCorsoCommandHandler(command, business);
        }
    }
}
