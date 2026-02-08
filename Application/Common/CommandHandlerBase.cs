using Application.Common.Interfaces;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public abstract class CommandHandlerBase
    {
        protected readonly IEventBus _eventBus;
        protected readonly IUnitOfWork _unitOfWork;

        protected CommandHandlerBase(
            IEventBus eventBus,
            IUnitOfWork unitOfWork)
        {
            _eventBus = eventBus;
            _unitOfWork = unitOfWork;
        }

        protected async Task CommitAsync(Entity aggregate, CancellationToken cancellationToken)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            //var domainEvents = aggregate.PopDomainEvents();
        }
    }
}
