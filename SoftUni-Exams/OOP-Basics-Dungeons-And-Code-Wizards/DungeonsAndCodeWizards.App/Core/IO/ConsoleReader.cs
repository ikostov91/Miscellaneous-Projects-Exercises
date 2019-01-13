using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.App.Core.Interfaces;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards.App.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
