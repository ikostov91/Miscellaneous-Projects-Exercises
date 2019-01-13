namespace Minedraft.Models.Exceptions
{
    using System;

    public class InvalidSystemModeException : Exception
    {
        public InvalidSystemModeException(string message) : base(message)
        {
        }

        public InvalidSystemModeException() : base()
        {
        }
    }
}
