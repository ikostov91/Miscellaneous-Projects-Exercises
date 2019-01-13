namespace StorageMaster.Models.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using StorageMaster.Models.Storages;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            if (objectType == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            Storage storage = (Storage) Activator.CreateInstance(objectType, name);
            return storage;
        }
    }
}
