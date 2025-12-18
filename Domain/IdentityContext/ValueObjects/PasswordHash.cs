using Domain.SeedWork;
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
            string hashed = HashPassword(rawPassword);
            return new PasswordHash(hashed);
        }

        private static void Validate(string password)
        {
            if (password.Length < 8)
                throw new Exception("Password quá ngắn");
            if (!password.Any(char.IsUpper))
                throw new Exception("Cần ít nhất 1 chữ hoa");
            if (!password.Any(char.IsLower))
                throw new Exception("Cần ít nhất 1 chữ thường");
            if (!password.Any(char.IsDigit))
                throw new Exception("Cần ít nhất 1 chữ số");
            if (!password.Any(c => "!@#$%^&*()".Contains(c)))
                throw new Exception("Cần ít nhất 1 ký tự đặc biệt");
        }

        private static string HashPassword(string password)
        {
            // Hash logic, ví dụ bcrypt hoặc SHA256
            return BCrypt.Net.BCrypt.HashPassword(password);
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
