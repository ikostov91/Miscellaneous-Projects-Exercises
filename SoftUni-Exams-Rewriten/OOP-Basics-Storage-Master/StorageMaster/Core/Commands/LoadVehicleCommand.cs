namespace StorageMaster.Core.Commands
{
    using Core.Interfaces;

    public class LoadVehicleCommand : ICommand
    {
        private StorageMaster storageMaster;

        public LoadVehicleCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.LoadVehicle(input);
            return output;
        }
    }
}
