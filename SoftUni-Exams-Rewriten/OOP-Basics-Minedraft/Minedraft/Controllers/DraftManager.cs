using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private SystemMode currentSystemMode;
    private List<Harvester> registeredHarvesters;
    private List<Provider> registeredProviders;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private double energyModifier;
    private double oreModifier;

    public DraftManager()
    {
        this.currentSystemMode = SystemMode.Full;
        this.energyModifier = 1;
        this.oreModifier = 1;
        this.registeredHarvesters = new List<Harvester>();
        this.registeredProviders = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.totalStoredEnergy = 0d;
        this.totalMinedOre = 0d;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        Harvester harvester = harvesterFactory.CreateHarvester(arguments);
        registeredHarvesters.Add(harvester);

        return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        Provider provider = providerFactory.CreateProvider(arguments);
        registeredProviders.Add(provider);

        return $"Successfully registered {arguments[0]} Provider - {provider.Id}";
    }

    public string Day()
    {
        double summedOreOutput = 0;
        double summedEnergyOutput = registeredProviders.Sum(p => p.EnergyOutput);
        double requiredEnergy = registeredHarvesters.Sum(h => h.EnergyRequirement) * this.energyModifier;
        this.totalStoredEnergy += summedEnergyOutput;

        if (requiredEnergy <= totalStoredEnergy)
        {
            summedOreOutput = registeredHarvesters.Sum(h => h.OreOutput) * this.oreModifier;
            this.totalMinedOre += summedOreOutput;
            this.totalStoredEnergy -= requiredEnergy;
        }

        return "A day has passed." + Environment.NewLine +
              $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
              $"Plumbus Ore Mined: {summedOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        bool isModeValid = Enum.TryParse<SystemMode>(arguments[0], out SystemMode newMode);

        if (!isModeValid)
        {
            throw new InvalidSystemModeException(ErrorMessages.InvalidSystemMode);
        }

        this.currentSystemMode = newMode;

        switch (this.currentSystemMode)
        {
            case SystemMode.Full:
                this.energyModifier = 1;
                this.oreModifier = 1;
                break;
            case SystemMode.Half:
                this.energyModifier = 0.6;
                this.oreModifier = 0.5;
                break;
            case SystemMode.Energy:
                this.energyModifier = 0;
                this.oreModifier = 0;
                break;
        }

        return $"Successfully changed working mode to {newMode.ToString()} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Harvester harvester = registeredHarvesters.FirstOrDefault(n => n.Id == id);
        Provider provider;

        if (harvester == null)
        {
            provider = registeredProviders.FirstOrDefault(n => n.Id == id);
        }
        else
        {
            return harvester.ToString();
        }

        if (provider == null)
        {
            return $"No element found with id - {id}";
        }

        return provider.ToString();
    }

    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {this.totalStoredEnergy}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {this.totalMinedOre}";
    }
}
