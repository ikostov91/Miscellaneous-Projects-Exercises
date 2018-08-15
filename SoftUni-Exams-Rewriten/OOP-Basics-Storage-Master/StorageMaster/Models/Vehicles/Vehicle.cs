using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly List<Product> products;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }
    }
}
