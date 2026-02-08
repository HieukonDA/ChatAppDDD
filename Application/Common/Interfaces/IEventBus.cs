using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEventBus
    {
        Task PublishAsync(IEnumerable<IDomainEvent> domainEvents);
    }
}
