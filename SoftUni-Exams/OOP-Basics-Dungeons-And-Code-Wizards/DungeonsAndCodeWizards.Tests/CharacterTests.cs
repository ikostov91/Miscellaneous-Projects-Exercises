using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using NUnit.Framework;

namespace DungeonsAndCodeWizards.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void CharacterArmorIsDepletedAfterSingleAttack()
        {
            Warrior pesho = new Warrior("Pesho", Faction.CSharp);
            Warrior gosho = new Warrior("Gosho", Faction.Java);
            pesho.Attack(gosho);

            Assert.That(gosho.Armor, Is.EqualTo(10));
        }

        [Test]
        public void CharacterHealthIsDepletedAfterMultipleAttacks()
        {
            Warrior pesho = new Warrior("Pesho", Faction.CSharp);
            Warrior gosho = new Warrior("Gosho", Faction.Java);
            pesho.Attack(gosho);
            pesho.Attack(gosho);

            Assert.That(gosho.Armor, Is.EqualTo(0));
            Assert.That(gosho.Health, Is.EqualTo(70));
        }

        [Test]
        public void CharacterDiesWhenHealthIsDepleted()
        {
            Warrior pesho = new Warrior("Pesho", Faction.CSharp);
            Warrior gosho = new Warrior("Gosho", Faction.Java);
            for (int attack = 1; attack <= 4; attack++)
            {
                pesho.Attack(gosho);
            }

            Assert.That(gosho.IsAlive, Is.EqualTo(false));
        }
    }
}
