using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Factories;
using DungeonsAndCodeWizards.Models.Interfaces;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private int lastSurvivorRounds;

        private readonly List<Character> dungeonParty;
        private readonly Stack<Item> itemPool;

        private readonly CharacterFactory characterFactory;
        private readonly ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.dungeonParty = new List<Character>();
            this.itemPool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            Character character = characterFactory.CreateCharacter(args);            
            this.dungeonParty.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemFactory.CreateItem(itemName);
            this.itemPool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = FindCharacter(characterName);

            bool anyItemsLeft = this.itemPool.Any();
            if (!anyItemsLeft)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = this.itemPool.Pop();
            character.RecieveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = FindCharacter(characterName);

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {item.GetType().Name}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giver.Name} used {item.GetType().Name} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giver.Name} gave {receiver.Name} {item.GetType().Name}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var allCharactersInParty = this.dungeonParty
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health)
                .ToArray();

            foreach (var character in allCharactersInParty)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);

            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Character receiver = FindCharacter(receiverName);

            attackingCharacter.Attack(receiver);

            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = FindCharacter(healerName);

            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Character receiver = FindCharacter(receiverName);

            healingCharacter.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var aliveCharacters = this.dungeonParty
                .Where(x => x.IsAlive)
                .ToArray();

            if (aliveCharacters.Length <= 1)
            {
                lastSurvivorRounds++;
            }

            foreach (var character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds > 1)
            {
                return true;
            }

            return false;
        }

        private Character FindCharacter(string characterName)
        {
            if (!dungeonParty.Any(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Character character = this.dungeonParty.Find(x => x.Name == characterName);
            return character;
        }
    }
}
