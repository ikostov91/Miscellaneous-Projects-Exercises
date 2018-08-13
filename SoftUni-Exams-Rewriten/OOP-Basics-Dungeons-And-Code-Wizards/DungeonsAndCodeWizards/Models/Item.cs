using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight
        {
            get { return this.weight; }
            private set { this.weight = value; } 
        }

        public abstract void AffectCharacter(Character character);
    }
}
