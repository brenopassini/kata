using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG_Kata;
using RPG_Kata.Interfaces;
using RPG_Kata.Iterations;
using RPG_Kata.Models;

namespace UnitTest_Kata
{
    [TestClass]
    public class UnitTest_Iteration1
    {
        private Character CreateCharacter()
        {
            CharacterModel characterModel = new CharacterModel()
            {
                Health = 1000,
                Level = 1
            };

            ICreate<Character> ch = new Character();
            return ch.Create(characterModel);
        }

        [TestMethod]
        public void TestCreate()
        {
            Character character = CreateCharacter();
            Assert.AreEqual(1000, character.Health, "Character health 1000");
            Assert.AreEqual(1, character.Level, "Character level 1");
            Assert.AreEqual(true, character.Alive, "Character alive");
        }

        [TestMethod]
        public void TestDamage()
        {
            Character character = CreateCharacter();
            int healthCalc = character.Health - 900;
            int healthExpected = healthCalc < 0 ? 0 : healthCalc;
            Iteration1 iteration1 = new Iteration1(character);
            iteration1.Damage(900);
            Assert.AreEqual(healthExpected, character.Health, "Damage done");
        }

        [TestMethod]
        public void TestCure()
        {
            Character character = CreateCharacter();
            int initialHealth = character.Health;
            Iteration1 iteration1 = new Iteration1(character);
            iteration1.Damage(900);
            iteration1.Cure(900);
            Assert.AreEqual(initialHealth, character.Health, "Cure done");
        }

        [TestMethod]
        public void TestKill()
        {
            Character character = CreateCharacter();
            int healthCalc = character.Health - 1000;
            int healthExpected = healthCalc < 0 ? 0 : healthCalc;
            Iteration1 iteration1 = new Iteration1(character);
            iteration1.Damage(1000);
            Assert.AreEqual(healthExpected, character.Health, "Damage done");
            Assert.AreEqual(false, character.Alive, "Damage done");
        }

        [TestMethod]
        public void TestCure2()
        {
            Character character = CreateCharacter();
            int maxHealth = character.MaxHealth;
            Iteration1 iteration1 = new Iteration1(character);
            iteration1.Cure(200);
            Assert.AreEqual(maxHealth, character.Health, "Cure limit");
        }
    }
}
