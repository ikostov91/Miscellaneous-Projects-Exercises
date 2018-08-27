namespace StorageMaster.Models.Storages
{
    using StorageMaster.Models.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;

        private static readonly Vehicle[] DefaultVehicles = { new Truck() };

        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, DefaultVehicles)
        {
        }
    }
}
