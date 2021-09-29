using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CQRS.Domain.Commands.Abstract
{
    public interface ICommand<out TResult> { }
}
