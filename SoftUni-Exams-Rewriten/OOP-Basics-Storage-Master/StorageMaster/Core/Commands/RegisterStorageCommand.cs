using System;
using System.Collections.Generic;
namespace StorageMaster.Core.Commands
{
    using Core.Interfaces;

    public class RegisterStorageCommand : ICommand
    {
        private StorageMaster storageMaster;

        public RegisterStorageCommand(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public string Execute(string[] input)
        {
            string output = this.storageMaster.RegisterStorage(input[0], input[1]);
            return output;
        }
    }
}
