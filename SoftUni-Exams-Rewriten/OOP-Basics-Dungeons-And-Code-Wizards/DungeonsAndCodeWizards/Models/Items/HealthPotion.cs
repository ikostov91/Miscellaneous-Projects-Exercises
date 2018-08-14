using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class HealthPotion : Item
    {
        private const int DefaultWeight = 5;

        public HealthPotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.EnsureAlive();

            character.Health += 20;
        }
    }
}
