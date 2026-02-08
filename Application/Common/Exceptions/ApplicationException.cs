using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        public string Code { get; }
        protected ApplicationException(string code) : base(code)
        {
            Code = code;
        }
    }
}
