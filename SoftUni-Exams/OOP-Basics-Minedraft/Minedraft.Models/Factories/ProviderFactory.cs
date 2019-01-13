namespace Minedraft.Models.Factories
{
    using Minedraft.Models.Exceptions;
    using Minedraft.Models.Providers;
    using System.Collections.Generic;

    public class ProviderFactory
    {
        public Provider CreateProvider(List<string> arguments)
        {
            string providerType = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);

            switch (providerType)
            {
                case "Solar":
                    return new SolarProvider(id, energyOutput);
                case "Pressure":
                    return new PressureProvider(id, energyOutput);
                default:
                    throw new InvalidProviderTypeException("Provider type is invalid");
            }
        }
    }
}
