using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;

        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];
            this.InitializeGarage(vehicles);
            this.products = new List<Product>();
        }

        public string Name {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Capacity {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int GarageSlots {
            get { return this.garageSlots; }
            private set { this.garageSlots = value; }
        }

        public bool IsFull => this.products.Select(x => x.Weight).Sum() >= capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage.ToList().AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.ToList().AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            var deliveryLocationHasFreeSlot = deliveryLocation.Garage.Any(x => x == null);
            if (!deliveryLocationHasFreeSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            var addedSlot = deliveryLocation.AddVehicle(vehicle);

            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            int unloadedProducts = 0;
            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);

                unloadedProducts++;
            }

            return unloadedProducts;
        }

        private int AddVehicle(Vehicle vehicle)
        {
            int freeGarageSlot = Array.IndexOf(this.garage, null);
            this.garage[freeGarageSlot] = vehicle;

            return freeGarageSlot;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            int garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot] = vehicle;
                garageSlot++;
            }
        }
    }
}
