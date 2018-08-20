namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using DungeonsAndCodeWizards.Models.Enums;
    using DungeonsAndCodeWizards.Models.Inventory;
    using DungeonsAndCodeWizards.Models.Items;

    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private double restHealMultiplier;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.faction = faction;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            private set
            {
                this.baseHealth = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                if (value < 0)
                {
                    value = 0;
                }
                this.health = value;
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            private set
            {
                this.baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints
        {
            get
            {
                return this.abilityPoints;
            }
            private set
            {
                this.abilityPoints = value;
            }
        }

        public Bag Bag
        {
            get
            {
                return this.bag;
            }
            private set
            {
                this.bag = value;
            }
        }

        public Faction Faction
        {
            get { return this.faction; }
        }

        public bool IsAlive { get; set; } = true;

        protected virtual double RestHealMultiplier => (double)1 / 5;

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double hitPointsAfterArmorDamage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0,this.Health - hitPointsAfterArmorDamage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            this.EnsureAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            character.RecieveItem(item);
        }

        public void RecieveItem(Item item)
        {
            this.EnsureAlive();

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {(this.IsAlive ? "Alive" : "Dead")}";
        }
    }
}
