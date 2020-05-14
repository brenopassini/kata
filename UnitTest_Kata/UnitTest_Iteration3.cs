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
    /// Summary description for UnitTest_Iteration3
    /// </summary>
    [TestClass]
    public class UnitTest_Iteration3
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

        private Character CreateCharacterRanged()
        {
            CharacterModel characterModel = new CharacterModel()
            {
                Health = 1000,
                Level = 1,
                TypeCharacter = TypeCharacter.RangedFighters,
            };

            ICreate<Character> ch = new Character();
            return ch.Create(characterModel);
        }

        [TestMethod]
        public void TestCreate()
        {
            Character character = CreateCharacterMelee();
            Assert.AreEqual(1000, character.Health, "Character health 1000");
            Assert.AreEqual(1, character.Level, "Character level 1");
            Assert.AreEqual(true, character.Alive, "Character alive");
        }

        [TestMethod]
        public void TestAtack()
        {
            try
            {
                Character characterMelee = CreateCharacterMelee();
                Character characterRanged = CreateCharacterRanged();

                Iteration3 iteration3 = new Iteration3(characterMelee, characterRanged);
                iteration3.Damage(200);
                Assert.IsTrue(true, "Atack done");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, "Atack fail");
            }
        }
    }
}
