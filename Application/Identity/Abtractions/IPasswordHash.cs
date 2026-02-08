using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity.Abtractions
{
    public interface IPasswordHash
    {
        bool Verify(string hashedPassword, string rawPassword);
        string Hash(string password);
    }
}
