using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Interfaces
{
    interface ICharacterActions
    {
        void Damage(int damageValue);

        void Cure(int cureValue);
    }
}
