using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        protected DomainEvent() 
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
