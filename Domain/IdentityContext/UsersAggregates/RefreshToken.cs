using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.UsersAggregates
{
    public class RefreshToken : Entity
    {
        public RefreshTokenId Id { get; private set; }
        public RefreshTokenValue Value { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsRevoked { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public string? CreatedByIp { get; private set; }
        public string? RevokedByIp { get; private set; }

        public UserId UserId { get; private set; }

        private RefreshToken() { }

        internal RefreshToken(RefreshTokenValue token,
            DateTime expiresAt,
            DateTime? revokedAt,
            string? createByIp,
            string? revokedByIp,
            UserId userId)
        {
            Id = RefreshTokenId.New();
            Value = token;
            ExpiresAt = expiresAt;
            IsRevoked = false;
            RevokedAt = revokedAt;
            CreatedByIp = createByIp;
            RevokedByIp = revokedByIp;
            UserId = userId;
        }

        public bool IsExpired()
        {
            return DateTime.UtcNow >= ExpiresAt;
        }

        public void Revoke()
        {
            if(IsRevoked)
                throw new InvalidOperationException("Token is already revoked.");

            IsRevoked = true;
        }
    }
}
