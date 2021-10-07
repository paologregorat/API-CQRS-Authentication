using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Utenti
{
    public static class UtenteCommandHandlerFactory
    {
        public static ICommandHandler<SaveUtenteCommand, CommandResponse> Build(SaveUtenteCommand command, UtentiBusiness business)
        {
            return new SaveUtenteCommandHandler(command, business);
        }
        
        public static ICommandHandler<CheckUtenteCommand, CommandResponse> Build(CheckUtenteCommand command, UtentiBusiness business)
        {
            return new CheckUtenteCommandHandler(command, business);
        }
    }
}
