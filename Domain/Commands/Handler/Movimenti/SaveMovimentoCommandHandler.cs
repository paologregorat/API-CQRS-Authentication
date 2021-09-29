using WebAPI_CQRS.Business.Movimenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Movimenti
{
    public class SaveMovimentoCommandHandler : ICommandHandler<SaveMovimentoCommand, CommandResponse>
    {
        private readonly SaveMovimentoCommand _command;
        private readonly MovimentiBusiness _business;
        public SaveMovimentoCommandHandler(SaveMovimentoCommand command, MovimentiBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.Save(_command);
        }
    }
}
