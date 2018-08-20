using System;
using DungeonsAndCodeWizards.Core;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Enums;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DungeonsAndCodeWizards.Tests
{
    [TestFixture]
    public class DungeonMasterTests
    {
        private DungeonMaster dungeonMaster;

        [SetUp]
        public void SetUpTests()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        [Test]
        public void ValidCharacterJoinsParty()
        {
            string expectedOutput = "Pesho joined the party!";

            Assert.That(this.dungeonMaster.JoinParty(new [] {"CSharp","Warrior","Pesho"}), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ValidItemIsAddedToPool()
        {
            string expectedOutput = "HealthPotion added to pool.";

            Assert.AreEqual(this.dungeonMaster.AddItemToPool(new [] {"HealthPotion"}), expectedOutput);
        }

        [Test]
        public void CharacterPicksUpItemSuccessfully()
        {
            string expectedOutput = "Gosho picked up ArmorRepairKit!";

            this.dungeonMaster.JoinParty(new[] {"Java","Cleric","Gosho"});
            this.dungeonMaster.AddItemToPool(new[] {"ArmorRepairKit"});

            Assert.That(this.dungeonMaster.PickUpItem(new [] { "Gosho" }), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ItemPickUpAttemptWhenPoolIsEmptyThrowsException()
        {
            this.dungeonMaster.JoinParty(new[] {"Java", "Warrior", "Ivan"});

            //Assert.Throws<InvalidOperationException>(() => this.dungeonMaster.PickUpItem(new [] { "Ivan" }));
            Assert.That(() => this.dungeonMaster.PickUpItem(new [] {"Ivan"}), Throws.InvalidOperationException.With.Message.EqualTo("No items left in pool!"));
        }

        [Test]
        public void CharacterSuccessfullyUsesItem()
        {
            string expectedOutput = "Ivan used HealthPotion.";

            this.dungeonMaster.JoinParty(new[] {"CSharp","Warrior","Ivan"});
            this.dungeonMaster.AddItemToPool(new[] {"HealthPotion"});
            this.dungeonMaster.PickUpItem(new[] {"Ivan"});

            Assert.AreEqual(this.dungeonMaster.UseItem(new [] {"Ivan","HealthPotion"}), expectedOutput);
        }

        [Test]
        public void CharacterCannotAttackSelf()
        {
            string expectedOutput = "Cannot attack self!";

            this.dungeonMaster.JoinParty(new[] {"CSharp","Warrior","Pesho"});

            Assert.That(() => this.dungeonMaster.Attack(new [] {"Pesho", "Pesho"}), Throws.InvalidOperationException.With.Message.EqualTo(expectedOutput));
        }

        [Test]
        public void CharactersFromSameFactionCannotAttackEachOther()
        {
            string expectedOutput = "Friendly fire! Both characters are from Java faction!";

            this.dungeonMaster.JoinParty(new[] { "Java", "Warrior", "Pesho" });
            this.dungeonMaster.JoinParty(new[] { "Java", "Warrior", "Gosho" });

            Assert.That(() => this.dungeonMaster.Attack(new[] { "Pesho", "Gosho" }), Throws.ArgumentException.With.Message.EqualTo(expectedOutput));
        }

        [Test]
        public void CharacterSuccessfullyAttacksEnemy()
        {
            string expectedOutput = "Pesho attacks Gosho for 40 hit points! Gosho has 100/100 HP and 10/50 AP left!";

            this.dungeonMaster.JoinParty(new[] { "CSharp", "Warrior", "Pesho" });
            this.dungeonMaster.JoinParty(new[] { "Java", "Warrior", "Gosho" });

            Assert.That(() => this.dungeonMaster.Attack(new[] { "Pesho", "Gosho" }), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void CharacterIsDeadAfterSuccessfullAttack()
        {
            string expectedOutput = "Pesho attacks Gosho for 40 hit points! Gosho has 0/100 HP and 0/50 AP left!" + Environment.NewLine + "Gosho is dead!";

            this.dungeonMaster.JoinParty(new[] { "CSharp", "Warrior", "Pesho" });
            this.dungeonMaster.JoinParty(new[] { "Java", "Warrior", "Gosho" });

            for (int attack = 1; attack <= 3; attack++)
            {
                this.dungeonMaster.Attack(new[] {"Pesho", "Gosho"});
            }

            Assert.That(() => this.dungeonMaster.Attack(new[] { "Pesho", "Gosho" }), Is.EqualTo(expectedOutput));
        }
    }
}
