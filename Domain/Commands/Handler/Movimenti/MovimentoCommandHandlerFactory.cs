using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Movimenti
{
    public static class MovimentoCommandHandlerFactory
    {
        public static ICommandHandler<SaveMovimentoCommand, CommandResponse> Build(SaveMovimentoCommand command, MovimentiBusiness business)
        {
            return new SaveMovimentoCommandHandler(command, business);
        }
    }
}
