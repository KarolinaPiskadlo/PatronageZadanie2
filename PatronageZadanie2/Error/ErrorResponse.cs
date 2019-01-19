using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronageZadanie2.Error
{
    public class ErrorResponse
    {
        public long Time { get; }
        public string Message { get; }

        public ErrorResponse(string message)
        {
            Message = message;
            Time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}
