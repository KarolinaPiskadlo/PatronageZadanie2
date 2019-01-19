using System;

namespace PatronageZadanie2.Error
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
    }
}
