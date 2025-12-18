using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        private PhoneNumber() { }

        private PhoneNumber(string phoneNumber)
        {
            // Simple validation example
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Value is required");
            if (!phoneNumber.All(char.IsDigit) || phoneNumber.Length < 9 || phoneNumber.Length > 12)
                throw new ArgumentException("Value is invalid");
            Value = phoneNumber;
        }

        public static PhoneNumber Create(string phoneNumber)
        {
            return new PhoneNumber(phoneNumber);
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
