

namespace DungeonsAndCodeWizards.Models.Factories
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using DungeonsAndCodeWizards.App.Core.StaticData;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            Item item;
            switch (itemName)
            {
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return item;
        }
    }
}
