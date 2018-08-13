﻿using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Interfaces;

namespace DungeonsAndCodeWizards.Models
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new InvalidOperationException($"Friendly fire! Both characters are from {this.Faction.ToString()} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
