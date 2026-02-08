using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork.Exceptions
{
    public sealed class RequireDomainException : DomainException
    {
        private RequireDomainException(string code, string message) : base(code, message)
        {
        }
        public static RequireDomainException Field(string fieldName)
            => new("Domain.Require.Field", $"The field '{fieldName}' is required!");
    }
}
