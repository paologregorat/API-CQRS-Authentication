using WebAPI_CQRS.Business.Operatori;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Command;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Handler.Operatori
{
    public class CreteTokenCommandHandler : ICommandHandler<CreateTokenCommand, CommandResponse>
    {
        private readonly CreateTokenCommand _command;
        private readonly OperatoriBusiness _business;
        public CreteTokenCommandHandler(CreateTokenCommand command, OperatoriBusiness business)
        {
            _command = command;
            _business = business;
        }
        public CommandResponse Execute()
        {
            return _business.CreteToken(_command);
        }
    }
}
