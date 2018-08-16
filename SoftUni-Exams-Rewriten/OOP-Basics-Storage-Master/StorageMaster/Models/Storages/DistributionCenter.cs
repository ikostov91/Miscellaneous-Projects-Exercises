using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultGarageSlots = 5;

        private static Vehicle[] vehicles = { new Van(), new Van(), new Van() };

        public DistributionCenter(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
