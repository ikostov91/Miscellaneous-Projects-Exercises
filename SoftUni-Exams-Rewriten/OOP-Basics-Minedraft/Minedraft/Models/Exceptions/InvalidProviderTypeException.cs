using System;

public class InvalidProviderTypeException : Exception
{
    public InvalidProviderTypeException(string message) : base(message)
    {
    }

    public InvalidProviderTypeException() : base()
    {
    }
}

