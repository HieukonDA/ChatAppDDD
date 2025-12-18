using Domain.IdentityContext.ValueObjects;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.DomainEvents
{
    public sealed class UserPasswordChanged : DomainEvent
    {
        public UserId UserId { get; }
        public UserPasswordChanged(UserId userId)
        {
            UserId = userId;
        }
    }
}
