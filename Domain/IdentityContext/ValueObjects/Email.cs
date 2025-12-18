using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        private Email() { }

        private Email(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Value is required");
            if(!email.Contains("@"))
                throw new ArgumentException("Value is invalid");
            Value = email.ToLower().Trim();
        }
        public static Email Create(string email)
        {
            return new Email(email);
        }

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
