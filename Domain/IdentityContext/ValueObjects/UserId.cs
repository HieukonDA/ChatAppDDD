using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Id { get; private set; }

        private UserId() { }

        private UserId(Guid id)
        {
            Id = id;
        }
        public static UserId Create(Guid id)
        {
            return new UserId(id);
        }
        public static UserId New()
        {
            return new UserId(Guid.NewGuid());
        }
        public override string ToString()
        {
            return Id.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

    }
}
