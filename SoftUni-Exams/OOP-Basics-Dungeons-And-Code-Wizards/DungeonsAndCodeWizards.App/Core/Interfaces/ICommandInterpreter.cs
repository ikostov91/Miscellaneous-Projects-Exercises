using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.App.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string input);
    }
}
