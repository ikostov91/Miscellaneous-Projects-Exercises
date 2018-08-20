namespace DungeonsAndCodeWizards.Models.Inventory
{
    public class Backpack : Bag
    {
        private const int DefaultCapacity = 100;

        public Backpack()
            : base(DefaultCapacity)
        {
        }
    }
}
