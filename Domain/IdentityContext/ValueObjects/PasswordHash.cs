using Domain.SeedWork;
using Domain.SeedWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class PasswordHash : ValueObject
    {
        public string Value { get; private set; }

        private PasswordHash() { }

        private PasswordHash(string hashed)
        {
            Value = hashed;
        }

        public static PasswordHash Create(string rawPassword)
        {
            Validate(rawPassword);
            return new PasswordHash(rawPassword);
        }

        private static void Validate(string password)
        {
            if (password.Length < 8)
                throw InvalidDomainException.Entity("Password","Password too short");
            if (!password.Any(char.IsUpper))
                throw InvalidDomainException.Entity("Password","Need least 1 upper character");
            if (!password.Any(char.IsLower))
                throw InvalidDomainException.Entity("Password","Need least 1 lower character");
            if (!password.Any(char.IsDigit))
                throw InvalidDomainException.Entity("Password","Need least 1 digit");
            if (!password.Any(c => "!@#$%^&*()".Contains(c)))
                throw InvalidDomainException.Entity("Password","need least 1 special character");
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
