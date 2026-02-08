using Application.Common.Interfaces;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        public Task PublishAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            return Task.CompletedTask;
        }
    }
}
