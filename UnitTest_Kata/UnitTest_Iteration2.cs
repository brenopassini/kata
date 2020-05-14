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
    /// Summary description for UnitTest_Iteration2
    /// </summary>
    [TestClass]
    public class UnitTest_Iteration2
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
            Character characterEnemy = CreateCharacter();
            Assert.AreEqual(1000, character.Health, "Character health 1000");
            Assert.AreEqual(1, character.Level, "Character level 1");
            Assert.AreEqual(true, character.Alive, "Character alive");

            Assert.AreEqual(1000, characterEnemy.Health, "Character health 1000");
            Assert.AreEqual(1, characterEnemy.Level, "Character level 1");
            Assert.AreEqual(true, characterEnemy.Alive, "Character alive");
        }

        [TestMethod]
        public void TestOwnDamage()
        {
            Character character = CreateCharacter();
            int initialHealthCharacter = character.Health;

            Character characterEnemy = CreateCharacter();
            int healthCalc = characterEnemy.Health - 900;
            int healthExpected = healthCalc < 0 ? 0 : healthCalc;

            Iteration2 iteration2 = new Iteration2(character, characterEnemy);
            iteration2.Damage(900);

            Assert.AreEqual(initialHealthCharacter, character.Health, "No damage");
            Assert.AreEqual(healthExpected, characterEnemy.Health, "Damagem done");
        }

        [TestMethod]
        public void TestCure()
        {
            Character character = CreateCharacter();
            int initialHealthCharacter = character.Health;
            int healthCalc = character.Health - 900;
            int healthExpected = healthCalc < 0 ? 0 : healthCalc;

            Character characterEnemy = CreateCharacter();
            int initialHealthCharacterEnemy = character.Health;
            int healthCalcEnemy = characterEnemy.Health - 900;
            int healthExpectedEnemy = healthCalcEnemy < 0 ? 0 : healthCalc;

            Iteration2 iteration2 = new Iteration2(character, characterEnemy);
            iteration2.Damage(900);
            initialHealthCharacterEnemy = characterEnemy.Health;
            Assert.AreEqual(initialHealthCharacter, character.Health, "No damage");
            Assert.AreEqual(healthExpectedEnemy, characterEnemy.Health, "Damagem done");

            Iteration2 iteration2Inverse = new Iteration2(characterEnemy, character);
            iteration2Inverse.Damage(900);
            initialHealthCharacter = character.Health;
            Assert.AreEqual(initialHealthCharacterEnemy, characterEnemy.Health, "No damage");
            Assert.AreEqual(healthExpected, character.Health, "Damagem done");

            iteration2.Cure(900);
            Assert.AreEqual(character.MaxHealth, character.Health, "Cure done");

            iteration2Inverse.Cure(900);
            Assert.AreEqual(characterEnemy.MaxHealth, characterEnemy.Health, "Cure done");
        }

        [TestMethod]
        public void TestReducedDamage()
        {
            Character character = CreateCharacter();

            Character characterEnemy = CreateCharacter();
            characterEnemy.Level += 5;

            Iteration2 iteration2 = new Iteration2(character, characterEnemy);
            iteration2.Damage(100);

            Assert.AreEqual(characterEnemy.MaxHealth - 50, characterEnemy.Health, "Reduced damage");
        }

        [TestMethod]
        public void TestIncreasedDamage()
        {
            Character character = CreateCharacter();
            character.Level += 5;

            Character characterEnemy = CreateCharacter();

            Iteration2 iteration2 = new Iteration2(character, characterEnemy);
            iteration2.Damage(100);

            Assert.AreEqual(characterEnemy.MaxHealth - 150, characterEnemy.Health, "Increased damage");
        }
    }
}
