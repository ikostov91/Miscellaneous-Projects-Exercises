namespace Minedraft.Models.Exceptions
{
    using System;

    public class ProviderNotRegisteredException : Exception
    {
        public ProviderNotRegisteredException(string message) : base(message)
        {
        }

        public ProviderNotRegisteredException() : base()
        {
        }
    }
}
