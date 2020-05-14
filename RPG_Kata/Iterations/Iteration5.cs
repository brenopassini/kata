using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Iterations
{
    public class Iteration5 : ICharacterActions
    {
        private Thing thing;

        public Iteration5(Thing thing)
        {
            this.thing = thing;
        }


        public void Damage(int damageValue)
        {
            if (this.thing.HasHealth)
            {
                if (this.thing.Health <= damageValue)
                {
                    this.thing.Health = 0;
                    this.thing.HasHealth = false;
                }
                else
                {
                    this.thing.Health -= damageValue;
                }
            }
        }

        public void Cure(int cureValue)
        {
            throw new NotImplementedException();
        }
    }
}
