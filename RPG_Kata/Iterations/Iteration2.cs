using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Iterations
{
    public class Iteration2 : ICharacterActions
    {
        private Character character;
        private Character enemyCharacter;

        public Iteration2(Character character, Character enemyCharacter)
        {
            this.character = character;
            this.enemyCharacter = enemyCharacter;
        }

        public void Damage(int damageValue)
        {
            if (enemyCharacter != character)
            {
                if ((enemyCharacter.Level - 5) >= this.character.Level)
                {
                    damageValue = Convert.ToInt32(damageValue * 0.5);
                }

                if ((enemyCharacter.Level + 5) <= this.character.Level)
                {
                    damageValue = damageValue + Convert.ToInt32(damageValue * 0.5);
                }

                if (damageValue > enemyCharacter.Health)
                {
                    enemyCharacter.Health = 0;
                    enemyCharacter.Alive = false;
                }
                else
                {
                    enemyCharacter.Health -= damageValue;
                }
            }
        }

        public void Cure(int cureValue)
        {
            if (character != enemyCharacter)
            {
                if (character.Alive)
                {
                    if ((character.Health + cureValue) <= character.MaxHealth)
                    {
                        character.Health += cureValue;
                    }
                }
            }
        }
    }
}
