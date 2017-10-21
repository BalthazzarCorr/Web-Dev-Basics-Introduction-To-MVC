using System;

namespace SimpleMvc.WebServer.Contracts.Exceptions
{
   public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}
