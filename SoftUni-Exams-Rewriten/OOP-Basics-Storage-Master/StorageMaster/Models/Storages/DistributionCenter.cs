namespace StorageMaster.Models.Storages
{
    using StorageMaster.Models.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultGarageSlots = 5;

        private static readonly Vehicle[] DefaultVehicles = { new Van(), new Van(), new Van() };

        public DistributionCenter(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, DefaultVehicles)
        {
        }
    }
}
