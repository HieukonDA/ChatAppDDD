using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Abtractions
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userId, string userName, string email);
        string GenerateRefreshToken();
    }
}
