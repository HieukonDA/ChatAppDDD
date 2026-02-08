using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class RefreshTokenId : ValueObject
    {
        public Guid Id { get; private set; }

        private RefreshTokenId() { }

        private RefreshTokenId(Guid id)
        {
            Id = id;
        }

        public static RefreshTokenId Create(Guid id)
        {
            return new RefreshTokenId(id);
        }

        public static RefreshTokenId New()
        {
            return new RefreshTokenId(Guid.NewGuid());
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
