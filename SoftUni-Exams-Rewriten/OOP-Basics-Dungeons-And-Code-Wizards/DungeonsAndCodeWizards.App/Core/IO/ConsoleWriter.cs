using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards.App.AppCore.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
