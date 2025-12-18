using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.DomainEvents
{
    public sealed class UserLoggedIn : DomainEvent
    {
        public UserId UserId { get; }
        public DateTime LoginTime { get; }
        public UserLoggedIn(UserId userId, DateTime loginTime)
        {
            UserId = userId;
            LoginTime = loginTime;
        }
    }
}
