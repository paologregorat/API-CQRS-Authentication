using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Corsi
{
    public static class CorsoCommandHandlerFactory
    {
        public static ICommandHandler<SaveCorsoCommand, CommandResponse> Build(SaveCorsoCommand command, CorsiBusiness business)
        {
            return new SaveCorsoCommandHandler(command, business);
        }
    }
}
