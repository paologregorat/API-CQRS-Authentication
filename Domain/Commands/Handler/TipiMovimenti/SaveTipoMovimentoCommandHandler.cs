using WebAPI_CQRS.Business.TipiMovimenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.TipiMovimenti
{
    public class SaveTipoMovimentoCommandHandler : ICommandHandler<SaveTipoMovimentoCommand, CommandResponse>
    {
        private readonly SaveTipoMovimentoCommand _command;
        private readonly TipiMovimentiBusiness _business;
        public SaveTipoMovimentoCommandHandler(SaveTipoMovimentoCommand command, TipiMovimentiBusiness business)
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
