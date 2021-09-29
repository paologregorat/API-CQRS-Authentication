using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Business.TipiCorsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.TipiCorsi
{
    public class SaveTipoCorsoCommandHandler : ICommandHandler<SaveTipoCorsoCommand, CommandResponse>
    {
        private readonly SaveTipoCorsoCommand _command;
        private readonly TipiCorsiBusiness _business;
        public SaveTipoCorsoCommandHandler(SaveTipoCorsoCommand command, TipiCorsiBusiness business)
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
