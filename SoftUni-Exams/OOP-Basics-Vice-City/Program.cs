using System;
using ViceCity.Core;
using ViceCity.Core.Contracts;

namespace OOP_Basics_Vice_City
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
