using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string[] args)
        {
            Faction? factionType = Enum.TryParse<Faction>(args[0], out var faction) ? faction : (Faction?)null;
            string characterType = args[1];
            string name = args[2];

            if (factionType == null)
            {
                throw new ArgumentException($"Invalid faction \"{args[0]}\"!");
            }

            Character character;
            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, (Faction)factionType);
                    break;
                case "Cleric":
                    character = new Cleric(name, (Faction)factionType);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type {characterType}");
            }

            return character;
        }
    }
}
