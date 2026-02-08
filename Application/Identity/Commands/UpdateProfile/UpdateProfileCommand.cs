using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Commands.UpdateProfile
{
    public sealed record UpdateProfileCommand
    (
        Guid UserId,
        string? Email,
        string? UserName,
        string? PhoneNumber,
        string? AvatarUrl
    );
}
