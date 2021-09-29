using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_CQRS.Domain.Commands.Abstract;
using WebAPI_CQRS.Domain.Commands.Handler;
using WebAPI_CQRS.Domain.Entity;

namespace WebAPI_CQRS.Domain.Commands.Command
{
    public class CreateTokenCommand : ICommand<CommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CreateTokenCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
