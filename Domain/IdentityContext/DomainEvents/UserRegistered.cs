using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.DomainEvents
{
    public sealed class UserRegistered : DomainEvent
    {
        public UserId UserId { get; }
        public UserRegistered(UserId userId)
        {
            UserId = userId;
        }
    }
}
