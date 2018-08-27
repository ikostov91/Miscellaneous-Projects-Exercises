namespace StorageMaster.App.Core.Commands
{
    using Core.Interfaces;

    public class AddProductCommand : ICommand
    {
        private StorageMaster storageMaster;

        public AddProductCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.AddProduct(input[0], double.Parse(input[1]));
            return output;
        }
    }
}
