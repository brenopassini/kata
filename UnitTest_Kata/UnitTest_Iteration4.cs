using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG_Kata;
using RPG_Kata.Models;
using RPG_Kata.Interfaces;
using RPG_Kata.Iterations;

namespace UnitTest_Kata
{
    /// <summary>
    /// Summary description for UnitTest_Iteration4
    /// </summary>
    [TestClass]
    public class UnitTest_Iteration4
    {
        private Character CreateCharacterMelee()
        {
            CharacterModel characterModel = new CharacterModel()
            {
                Health = 1000,
                Level = 1,
                TypeCharacter = TypeCharacter.Melee,
            };

            ICreate<Character> ch = new Character();
            return ch.Create(characterModel);
        }

        private Faction CreateFaction()
        {
            var r = Guid.NewGuid().ToString();

            return new Faction()
            {
                FactionID = $"FactionID_{r}",
                FactionName = $"FactionName_{r}"
            };
        }

        [TestMethod]
        public void TestCreate()
        {
            Character character = CreateCharacterMelee();
            Assert.AreEqual(1000, character.Health, "Character health 1000");
            Assert.AreEqual(1, character.Level, "Character level 1");
            Assert.AreEqual(true, character.Alive, "Character alive");
            Assert.AreEqual(0, character.Factions.Count, "There is no faction");
        }

        [TestMethod]
        public void TestJoinFaction()
        {
            Character character = CreateCharacterMelee();
            Character characterEnemy = CreateCharacterMelee();
            Faction newFaction = CreateFaction();
            Iteration4 iteration4 = new Iteration4(character, characterEnemy);
            iteration4.JoinFaction(newFaction, character);

            Assert.AreEqual(true, character.Factions.Contains(newFaction), "Join faction");
        }

        [TestMethod]
        public void TestJoinAndLeaveFaction()
        {
            Character character = CreateCharacterMelee();
            Character characterEnemy = CreateCharacterMelee();
            Faction newFaction = CreateFaction();
            Iteration4 iteration4 = new Iteration4(character, characterEnemy);
            iteration4.JoinFaction(newFaction, character);
            iteration4.LeaveFaction(newFaction, character);

            Assert.AreEqual(false, character.Factions.Contains(newFaction), "Join faction");
        }

        [TestMethod]
        public void TestAlliesFaction()
        {
            Character character = CreateCharacterMelee();
            Character characterEnemy = CreateCharacterMelee();
            Faction newFaction = CreateFaction();
            Iteration4 iteration4 = new Iteration4(character, characterEnemy);
            iteration4.JoinFaction(newFaction, character);
            iteration4.JoinFaction(newFaction, characterEnemy);

            bool allies = iteration4.Allies(characterEnemy);
            Assert.AreEqual(true, allies, "Are allies");
        }

        [TestMethod]
        public void TestAlliesNotDamage()
        {
            Character character = CreateCharacterMelee();
            Character characterEnemy = CreateCharacterMelee();
            Faction newFaction = CreateFaction();
            Iteration4 iteration4 = new Iteration4(character, characterEnemy);
            iteration4.JoinFaction(newFaction, character);
            iteration4.JoinFaction(newFaction, characterEnemy);

            iteration4.Damage(200);
            Assert.AreEqual(characterEnemy.MaxHealth, characterEnemy.Health, "Not damage");
        }

        [TestMethod]
        public void TestCanCure()
        {
            Character character = CreateCharacterMelee();
            Character characterEnemy = CreateCharacterMelee();
            Faction newFaction = CreateFaction();
            Iteration4 iteration4 = new Iteration4(character, characterEnemy);
            iteration4.JoinFaction(newFaction, character);
            iteration4.Damage(200);
            iteration4.JoinFaction(newFaction, characterEnemy);
            iteration4.Cure(200);
            Assert.AreEqual(characterEnemy.MaxHealth, characterEnemy.Health, "Not damage");
        }
    }
}
