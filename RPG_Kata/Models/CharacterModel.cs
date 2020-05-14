using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Models
{
    public class CharacterModel
    {
        public int Health { get; set; }

        public int Level { get; set; }

        public int MaxRange { get; set; }

        public TypeCharacter TypeCharacter { get; set; }
    }
}
