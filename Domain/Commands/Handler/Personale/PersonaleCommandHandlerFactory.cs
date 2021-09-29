using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Personale
{
    public static class PersonaleCommandHandlerFactory
    {
        public static ICommandHandler<SavePersonaleCommand, CommandResponse> Build(SavePersonaleCommand command, PersonaleBusiness business)
        {
            return new SavePersonaleCommandHandler(command, business);
        }
    }
}
