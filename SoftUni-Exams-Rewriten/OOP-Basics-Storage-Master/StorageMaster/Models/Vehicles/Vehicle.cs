using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly Stack<Product> trunk;

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new Stack<Product>();
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

        public IReadOnlyCollection<Product> Trunk => this.trunk.ToList().AsReadOnly();

        public bool IsFull => this.trunk.Select(x => x.Weight).Sum() >= this.Capacity;

        public bool IsEmpty => !this.trunk.Any();

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full");
            }

            this.trunk.Push(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk.Pop();
            return product;
        }
    }
}
