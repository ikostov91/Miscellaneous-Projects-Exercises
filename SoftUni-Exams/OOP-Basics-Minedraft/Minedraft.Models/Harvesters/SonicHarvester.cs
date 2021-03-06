﻿namespace Minedraft.Models.Harvesters
{
    using System;

    public class SonicHarvester : Harvester
    {
        private const int MinSonicFactor = 0;

        private int sonicFactor;

        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
            : base(id, oreOutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            base.EnergyRequirement = InitializedEnergyRequirement(energyRequirement, sonicFactor);
        }

        private double InitializedEnergyRequirement(double energyRequirement, int sonicFactor)
        {
            double initialEnergyRequirement = energyRequirement / sonicFactor;
            return initialEnergyRequirement;
        }

        public int SonicFactor
        {
            get { return this.sonicFactor; }
            set
            {
                if (value <= MinSonicFactor)
                {
                    throw new ArgumentOutOfRangeException("Harvester is not registered, because of it's sonic factor");
                }

                this.sonicFactor = value;
            }
        }

        public override string ToString()
        {
            return $"Sonic Harvester - {this.Id}" + Environment.NewLine + base.ToString();
        }
    }
}
