namespace StorageMaster.Models.Storages
{
    using StorageMaster.Models.Vehicles;

    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;

        private static readonly Vehicle[] DefaultVehicles = { new Semi(), new Semi(), new Semi() };

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, DefaultVehicles)
        {
        }
    }
}
