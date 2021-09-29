using WebAPI_CQRS.Business.Personale;
using WebAPI_CQRS.Business.Utenti;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Personale
{
    public class SavePersonaleCommandHandler : ICommandHandler<SavePersonaleCommand, CommandResponse>
    {
        private readonly SavePersonaleCommand _command;
        private readonly PersonaleBusiness _business;
        public SavePersonaleCommandHandler(SavePersonaleCommand command, PersonaleBusiness business)
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
