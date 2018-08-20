using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
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
