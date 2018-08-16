using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;

        private static Vehicle[] vehicles = { new Truck() };

        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }

    }
}
