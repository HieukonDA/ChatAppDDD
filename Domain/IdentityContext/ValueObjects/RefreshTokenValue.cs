using Domain.SeedWork;
using Domain.SeedWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class RefreshTokenValue : ValueObject
    {
        public string Value { get; private set; }
        private RefreshTokenValue() { }

        private RefreshTokenValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw RequireDomainException.Field("RefreshTokenValue");

            Value = value;
        }

        public static RefreshTokenValue Create(string value)
        {
            return new RefreshTokenValue(value);
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
