﻿namespace Minedraft.Models.Harvesters
{
    using Minedraft.Models.Exceptions;
    using System;

    public abstract class Harvester
    {
        private const int MinOreOutput = 0;
        private const int MinEnergyRequirement = 0;
        private const int MaxEnergyRequirement = 20000;

        private string id;
        private double oreOutput;
        private double energyRequirement;

        protected Harvester(string id, double oreOutput, double energyRequirement)
        {
            this.Id = id;
            this.OreOutput = oreOutput;
            this.EnergyRequirement = energyRequirement;
        }

        public string Id
        {
            get { return this.id; }
            protected set { this.id = value; }
        }

        public double OreOutput
        {
            get { return this.oreOutput; }
            protected set
            {
                if (value < MinOreOutput)
                {
                    throw new HarvesterNotRegisteredException("Harvester is not registered, because of it's OreOutput");
                }

                this.oreOutput = value;
            }
        }

        public double EnergyRequirement
        {
            get { return this.energyRequirement; }
            protected set
            {
                if (value < MinEnergyRequirement || value > MaxEnergyRequirement)
                {
                    throw new HarvesterNotRegisteredException("Harvester is not registered, because of it's EnergyRequirement");
                }

                this.energyRequirement = value;
            }
        }

        public override string ToString()
        {
            return $"Ore Output: {this.OreOutput}" + Environment.NewLine +
                   $"Energy Requirement: {this.EnergyRequirement}";
        }
    }
}
