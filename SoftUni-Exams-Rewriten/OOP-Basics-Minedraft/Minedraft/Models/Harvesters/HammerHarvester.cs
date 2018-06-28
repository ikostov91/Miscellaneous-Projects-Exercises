using System;

public class HammerHarvester : Harvester
{
    private const int OreIncreasePercentage = 200;
    private const int EnergyIncreasePercentage = 100;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput = IncreaseInitialParameters(oreOutput, OreIncreasePercentage);
        base.EnergyRequirement = IncreaseInitialParameters(energyRequirement, EnergyIncreasePercentage);
    }

    private double IncreaseInitialParameters(double parameter, int percentage)
    {
        double resultValue = parameter + (parameter * percentage / 100);
        return resultValue;
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {this.Id}" + Environment.NewLine + base.ToString();
    }
}

