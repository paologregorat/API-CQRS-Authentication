using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Commands.Handler.Utenti;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.TipiMovimenti
{
    public static class TipoMovimentoCommandHandlerFactory
    {
        public static ICommandHandler<SaveTipoMovimentoCommand, CommandResponse> Build(SaveTipoMovimentoCommand command, TipiMovimentiBusiness business)
        {
            return new SaveTipoMovimentoCommandHandler(command, business);
        }
    }
}
