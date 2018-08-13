using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards.Models
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        protected override double RestHealMultiplier => (double)1 / 2;

        public void Heal(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
