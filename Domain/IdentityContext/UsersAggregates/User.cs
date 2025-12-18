using Domain.IdentityContext.DomainEvents;
using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.UsersAggregates
{
    public class User : Entity, IAggregateRoot
    {
        public UserId UserId { get; private set; }
        public Email Email { get; private set; }
        public UserName UserName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public PasswordHash PasswordHash { get; private set; }
        public AvatarUrl AvatarUrl { get; private set; }

        private User() { } // For ORM

        private User(UserId userId,Email email,UserName userName,PasswordHash passwordHash)
        {
            UserId = userId;
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
            AddDomainEvent(new UserProfileUpdated(UserId));
        }

        public void ChangeUsername(UserName userName)
        {
            UserName = userName;
            AddDomainEvent(new UserProfileUpdated(UserId));
        }

        public void ChangeAvatar(AvatarUrl avatarUrl)
        {
            AvatarUrl = avatarUrl;
        }

        public void ChangePassword(PasswordHash passwordHash)
        {
            PasswordHash = passwordHash;
            AddDomainEvent(new UserPasswordChanged(UserId));
        }

        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            AddDomainEvent(new UserProfileUpdated(UserId));
        }

    }
}
