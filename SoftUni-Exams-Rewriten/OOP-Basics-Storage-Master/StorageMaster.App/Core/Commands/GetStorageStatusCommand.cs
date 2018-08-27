namespace StorageMaster.App.Core.Commands
{
    using Core.Interfaces;

    public class GetStorageStatusCommand : ICommand
    {
        private StorageMaster storageMaster;

        public GetStorageStatusCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.GetStorageStatus(input[0]);
            return output;
        }
    }
}
