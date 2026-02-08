using Domain.SeedWork;
using Domain.SeedWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class UserName : ValueObject
    {
        public string Value { get; private set; }

        private UserName() { }

        private UserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw RequireDomainException.Field("UserName");
            if (userName.Length < 3 || userName.Length > 20)
                throw InvalidDomainException.Entity("UserName", "The username must be between 3 and 20 characters long.");
            Value = userName.Trim();
        }

        public static UserName Create(string userName)
        {
            return new UserName(userName);
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
