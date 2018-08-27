using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string input);
    }
}
