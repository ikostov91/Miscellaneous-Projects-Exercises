namespace Minedraft.Models.Exceptions
{
    using System;

    public class InvalidHarvesterTypeException : Exception
    {
        public InvalidHarvesterTypeException(string message) : base(message)
        {
        }

        public InvalidHarvesterTypeException() : base()
        {
        }
    }
}

