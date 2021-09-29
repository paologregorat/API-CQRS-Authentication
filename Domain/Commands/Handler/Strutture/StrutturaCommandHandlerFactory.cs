using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Strutture
{
    public static class StrutturaCommandHandlerFactory
    {
        public static ICommandHandler<SaveStrutturaCommand, CommandResponse> Build(SaveStrutturaCommand command, StruttureBusiness business)
        {
            return new SaveStrutturaCommandHandler(command, business);
        }
    }
}
