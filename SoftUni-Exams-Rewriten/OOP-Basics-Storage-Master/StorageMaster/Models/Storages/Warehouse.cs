using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;

        private static Vehicle[] vehicles = { new Semi(), new Semi(), new Semi() };

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, vehicles)
        {
        }
    }
}
