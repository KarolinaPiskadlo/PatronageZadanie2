using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronageZadanie2.Error
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}
