namespace StorageMaster.Core.Commands
{
    using Core.Interfaces;

    public class ENDCommand : ICommand
    {
        private StorageMaster storageMaster;

        public ENDCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.GetSummary();
            return output;
        }
    }
}
