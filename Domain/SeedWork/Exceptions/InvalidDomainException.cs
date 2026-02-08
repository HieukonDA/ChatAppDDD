using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork.Exceptions
{
    public sealed class InvalidDomainException : DomainException
    {
        private InvalidDomainException(string code, string message) : base(code, message)
        {
        }

        public static InvalidDomainException Entity(string entityName, string? message)
            => new("Domain.Invalid.Entity", $"The entity '{entityName}' is invalid! {message}");
    }
}
