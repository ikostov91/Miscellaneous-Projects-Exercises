using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int DefaultWeight = 5;

        public PoisonPotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.EnsureAlive();

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
