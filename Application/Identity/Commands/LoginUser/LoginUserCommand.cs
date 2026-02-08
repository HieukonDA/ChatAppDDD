using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.LoginUser
{
    public sealed record LoginUserCommand
    (
        string Email,
        string Password
    );
}
