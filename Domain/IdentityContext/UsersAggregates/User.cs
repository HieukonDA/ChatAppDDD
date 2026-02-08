using Domain.IdentityContext.DomainEvents;
using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.UsersAggregates
{
    public class User : Entity, IAggregateRoot
    {
        public UserId Id { get; private set; }
        public Email Email { get; private set; }
        public UserName UserName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public AvatarUrl AvatarUrl { get; private set; }
        private readonly List<RefreshToken> _refreshTokens = new(); // use backing field for encapsulation
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly(); // Encapsulation

        private User() { } // For ORM

        private User(UserId userId,Email email,UserName userName,PasswordHash passwordHash)
        {
            Id = userId;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
        }

        public static User Register(UserId userId,Email email,UserName userName,PasswordHash passwordHash)
        {
            var user = new User(userId,email,userName,passwordHash);
            user.AddDomainEvent(new UserRegistered(userId));
            return user;
        }

        public void ChangeEmail(Email email)
        {
            Email = email;
            AddDomainEvent(new UserProfileUpdated(Id));
        }

        public void ChangeUsername(UserName userName)
        {
            UserName = userName;
            AddDomainEvent(new UserProfileUpdated(Id));
        }

        public void ChangeAvatar(AvatarUrl avatarUrl)
        {
            AvatarUrl = avatarUrl;
        }

        public void ChangePassword(PasswordHash passwordHash)
        {
            PasswordHash = passwordHash;
            AddDomainEvent(new UserPasswordChanged(Id));
        }

        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            AddDomainEvent(new UserProfileUpdated(Id));
        }

        public RefreshToken IssueRefeshToken(RefreshTokenValue tokenValue,
            DateTime expiresAt,
            DateTime? revokedAt,
            string? createByIp,
            string? revokedByIp,
            UserId userId)
        {
            var refreshToken = new RefreshToken(tokenValue, expiresAt, revokedAt, createByIp, revokedByIp, userId);
            _refreshTokens.Add(refreshToken);

            AddDomainEvent(new UserLoggedIn(Id, DateTime.Now));
            return refreshToken;
        }

        public void RevokeRefreshToken(RefreshTokenValue tokenValue)
        {
            var token = _refreshTokens.FirstOrDefault(t => t.Value == tokenValue);
            token?.Revoke();
        }

        public bool HasValidRefreshToken(RefreshTokenValue tokenValue)
        {
            var token = _refreshTokens.FirstOrDefault(t => t.Value == tokenValue);

            if(token == null || token.IsRevoked || token.IsExpired())
                return false;

            return true;
        }

    }
}
