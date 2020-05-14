using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Iterations
{
    public class Iteration1 : ICharacterActions
    {
        private Character character;

        public Iteration1(Character character)
        {
            this.character = character;
        }

        public void Damage(int damageValue)
        {
            if (damageValue >= character.Health)
            {
                character.Health = 0;
                character.Alive = false;
            }
            else
            {
                character.Health -= damageValue;
            }
        }

        public void Cure(int cureValue)
        {
            if (character.Alive)
            {
                if ((character.Health + cureValue) <= character.MaxHealth)
                {
                    character.Health += cureValue;
                }
                else
                {
                    character.Health = character.MaxHealth;
                }
            }
        }
    }
}
