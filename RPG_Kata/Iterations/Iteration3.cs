using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Iterations
{
    public class Iteration3 : ICharacterActions
    {
        private Character character;
        private Character enemyCharacter;

        public Iteration3(Character character, Character enemyCharacter)
        {
            this.character = character;
            this.enemyCharacter = enemyCharacter;
        }

        public void Damage(int damageValue)
        {
            if (HasRangeToDamage())
            {
                this.enemyCharacter.Health -= damageValue;
            }
        }

        public void Cure(int cureValue)
        {
            throw new NotImplementedException();
        }

        private bool HasRangeToDamage()
        {
            Random r = new Random();
            return r.Next(character.MaxRange * 2) <= character.MaxRange ? true : false;
        }
    }
}
