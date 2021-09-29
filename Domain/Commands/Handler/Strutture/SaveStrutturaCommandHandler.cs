using WebAPI_CQRS.Business.Strutture;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Strutture
{
    public class SaveStrutturaCommandHandler : ICommandHandler<SaveStrutturaCommand, CommandResponse>
    {
        private readonly SaveStrutturaCommand _command;
        private readonly StruttureBusiness _business;
        public SaveStrutturaCommandHandler(SaveStrutturaCommand command, StruttureBusiness business)
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
