using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.App.Core.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] input);
    }
}
