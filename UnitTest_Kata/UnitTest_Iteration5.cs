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
    /// Summary description for UnitTest_Iteration5
    /// </summary>
    [TestClass]
    public class UnitTest_Iteration5
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
        private Thing CreateThing()
        {
            var guid = Guid.NewGuid().ToString();

            ThingModel thingModel = new ThingModel()
            {
                HasHealth = true,
                Health = 200,
                IdThing = guid,
                Name = $"Name_{guid}",
                TypeThing = TypeThing.Three
            };

            ICreate<Thing> ch = new Thing();
            return ch.Create(thingModel);
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
        public void TestThing()
        {
            Thing thing = CreateThing();
            Assert.AreEqual(true, thing != null, "Thing created");
        }

        [TestMethod]
        public void TestDestructThing()
        {
            Thing thing = CreateThing();

            Iteration5 iteration5 = new Iteration5(thing);
            iteration5.Damage(200);

            Assert.AreEqual(false, thing.HasHealth, "Thing destructed");
        }
    }
}
