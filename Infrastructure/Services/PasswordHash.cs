using Application.Identity.Abtractions;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Services
{
    public class PasswordHash : IPasswordHash
    {
        private readonly PasswordHasher<object> _hash = new PasswordHasher<object>();

        public string Hash(string password)
        {
            return _hash.HashPassword(null, password);
        }

        public bool Verify(string hashedPassword, string rawPassword)
        {
            try
            {
                var result = _hash.VerifyHashedPassword(null, hashedPassword, rawPassword);
                return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
