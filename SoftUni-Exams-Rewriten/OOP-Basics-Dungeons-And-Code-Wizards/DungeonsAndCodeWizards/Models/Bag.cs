using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private readonly List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string itemName)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!"); 
            }

            if (!this.items.Any(x => x.GetType().Name == itemName))
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            Item item = this.items.First(x => x.GetType().Name == itemName);
            this.items.Remove(item);

            return item;
        }
    }
}
