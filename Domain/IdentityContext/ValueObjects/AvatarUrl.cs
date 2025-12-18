using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IdentityContext.ValueObjects
{
    public class AvatarUrl : ValueObject
    {
        public string Value { get; private set; }

        private AvatarUrl() { }

        private AvatarUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Value is required");
            // Simple URL validation
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException("Value is invalid");
            Value = url.Trim();
        }

        public static AvatarUrl Create(string url)
        {
            return new AvatarUrl(url);
        }

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
