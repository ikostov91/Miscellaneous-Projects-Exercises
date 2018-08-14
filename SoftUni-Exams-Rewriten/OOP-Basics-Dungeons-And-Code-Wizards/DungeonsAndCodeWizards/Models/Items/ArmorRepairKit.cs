using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class ArmorRepairKit : Item
    {
        private const int weight = 10;

        public ArmorRepairKit()
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.EnsureAlive();

            character.Armor = character.BaseArmor;
        }
    }
}
