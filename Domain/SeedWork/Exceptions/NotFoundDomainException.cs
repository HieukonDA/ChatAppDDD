using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork.Exceptions
{
    public sealed class NotFoundDomainException : DomainException
    {
        private NotFoundDomainException(string code, string message) : base(code, message)
        {
        }

        public static NotFoundDomainException Entity(string entityName, object id)
            => new ("Domain.NotFound.Entity", $"The entity '{entityName}' ({id}) was not found.");

        public static NotFoundDomainException Field(string FieldName, object id)
            => new("Domain.NotFound.Field", $"The field '{FieldName}' ({id}) was not found.");

    }
}
