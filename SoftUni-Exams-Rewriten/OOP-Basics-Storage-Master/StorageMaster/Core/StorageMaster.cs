namespace StorageMaster.Core
{
    using Models;
    using Models.Storages;
    using Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.Factories;

    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private readonly List<Product> productPool;
        private readonly List<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
            this.currentVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            this.currentVehicle =
                this.storageRegistry
                .FirstOrDefault(x => x.Name == storageName)
                .GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                Product product = this.productPool.LastOrDefault(x => x.GetType().Name == productName);
                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                this.currentVehicle.LoadProduct(product);
                this.productPool.Remove(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage source = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            if (source == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Storage destination = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);
            if (destination == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            string vehicleType = source.GetVehicle(sourceGarageSlot).GetType().Name;
            int destinationGarageSlot = source.SendVehicleTo(sourceGarageSlot, destination);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count ;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            var productsWeight = storage.Products.Select(x => x.Weight).Sum();
            var storageCapacity = storage.Capacity;
            var productStockInfo = storage
                .Products
                .GroupBy(x => x.GetType().Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ({x.Count})")
                .ToArray();

            List<string> vehicleNames = new List<string>();
            foreach (var garageSlot in storage.Garage)
            {
                if (garageSlot == null)
                {
                    vehicleNames.Add("empty");
                }
                else
                {
                    vehicleNames.Add(garageSlot.GetType().Name);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Stock ({productsWeight}/{storageCapacity}): [{string.Join(", ", productStockInfo)}]");
            sb.AppendLine($"Garage: [{string.Join("|", vehicleNames)}]");

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storageRegistry.OrderByDescending(x => x.Products.Select(y => y.Price).Sum()))
            {
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Select(x => x.Price).Sum():F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
