using Domain.SeedWork;
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
                throw new ArgumentException("Value is required");
            if (userName.Length < 3 || userName.Length > 20)
                throw new ArgumentException("Value must be between 3 and 20 characters");
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
