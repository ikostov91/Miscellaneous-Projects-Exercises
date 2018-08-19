namespace StorageMaster.Core.Commands
{
    using Core.Interfaces;

    public class SendVehicleToCommand : ICommand
    {
        private StorageMaster storageMaster;

        public SendVehicleToCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.SendVehicleTo(input[0], int.Parse(input[1]), input[2]);
            return output;
        }
    }
}
