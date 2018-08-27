namespace Minedraft.Models.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PressureProvider : Provider
    {
        private const int EnergyIncreasePercentage = 50;

        public PressureProvider(string id, double energyOutput)
            : base(id, energyOutput)
        {
            base.EnergyOutput = IncreaseByPercentage(energyOutput, EnergyIncreasePercentage);
        }

        private double IncreaseByPercentage(double energyOutput, int percentage)
        {
            double result = energyOutput + (energyOutput * percentage / 100);
            return result;
        }

        public override string ToString()
        {
            return $"Pressure Provider - {this.Id}" + Environment.NewLine + base.ToString();
        }
    }
}
