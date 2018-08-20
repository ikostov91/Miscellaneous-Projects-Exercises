namespace DungeonsAndCodeWizards.Models.Inventory
{
    public class Satchel : Bag
    {
        private const int DefaultCapacity = 20;

        public Satchel()
            : base(DefaultCapacity)
        {
        }
    }
}
