namespace Minedraft.Models.Exceptions
{
    using System;

    public class HarvesterNotRegisteredException : Exception
    {
        public HarvesterNotRegisteredException(string message) : base(message)
        {
        }

        public HarvesterNotRegisteredException() : base()
        {
        }
    }
}