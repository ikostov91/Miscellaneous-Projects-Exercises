namespace StorageMaster.Core.Commands
{
    using Core.Interfaces;

    public class SelectVehicleCommand : ICommand
    {
        private StorageMaster storageMaster;

        public SelectVehicleCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.SelectVehicle(input[0], int.Parse(input[1]));
            return output;
        }
    }
}
