using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.TipiCorsi
{
    public static class TipoCorsoCommandHandlerFactory
    {
        public static ICommandHandler<SaveTipoCorsoCommand, CommandResponse> Build(SaveTipoCorsoCommand command, TipiCorsiBusiness business)
        {
            return new SaveTipoCorsoCommandHandler(command, business);
        }
    }
}
