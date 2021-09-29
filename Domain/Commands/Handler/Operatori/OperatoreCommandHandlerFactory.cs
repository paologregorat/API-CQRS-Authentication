using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Operatori;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Operatori;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Utenti
{
    public static class OperatoreCommandHandlerFactory
    {
        public static ICommandHandler<CreateTokenCommand, CommandResponse> Build(CreateTokenCommand command, OperatoriBusiness business)
        {
            return new CreteTokenCommandHandler(command, business);
        }
    }
}
