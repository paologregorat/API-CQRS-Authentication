using WebAPI_CQRS.Business.Corsi;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Corsi
{
    public class SaveCorsoCommandHandler : ICommandHandler<SaveCorsoCommand, CommandResponse>
    {
        private readonly SaveCorsoCommand _command;
        private readonly CorsiBusiness _business;
        public SaveCorsoCommandHandler(SaveCorsoCommand command, CorsiBusiness business)
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
