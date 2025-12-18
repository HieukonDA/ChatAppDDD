using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.DomainEvents
{
    public sealed class UserProfileUpdated : DomainEvent
    {
        public UserId UserId { get; }
        public UserProfileUpdated(UserId userId)
        {
            UserId = userId;
        }
    }
}
