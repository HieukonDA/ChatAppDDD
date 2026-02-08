using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public sealed class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException() : base("Auth.InvalidCredentials")
        {
        }
    }
}
