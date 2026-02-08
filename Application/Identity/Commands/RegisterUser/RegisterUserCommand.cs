using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.RegisterUser
{
    public sealed record RegisterUserCommand
    (
        string Email,
        string UserName,
        string Password
    );
}
