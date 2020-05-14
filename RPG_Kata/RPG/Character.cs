using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata
{
    public class Character : ICreate<Character>
    {
        private int _health { get; set; }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        private int _maxHealth;
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
            set
            {
                _maxHealth = value;
            }
        }

        private int _level { get; set; }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        private bool _alive { get; set; }
        public bool Alive
        {
            get
            {
                return _alive;
            }
            set
            {
                _alive = value;
            }
        }

        private int _maxRange { get; set; }
        public int MaxRange
        {
            get
            {
                return _maxRange;
            }
            set
            {
                _maxRange = value;
            }
        }

        private TypeCharacter _typeCharacter { get; set; }
        public TypeCharacter TypeCharacter
        {
            get
            {
                return _typeCharacter;
            }
            set
            {
                _typeCharacter = value;
            }
        }

        private List<Faction> _factions { get; set; }
        public List<Faction> Factions
        {
            get
            {
                return _factions;
            }
            set
            {
                _factions = value;
            }
        }

        public Character Create(object paramStart)
        {
            CharacterModel character = (CharacterModel)paramStart;

            Health = character.Health;
            Level = character.Level;
            Alive = true;
            MaxHealth = 1000;
            Factions = new List<Faction>();
            TypeCharacter = character.TypeCharacter;
            MaxRange = (int)character.TypeCharacter;
            return this;
        }
    }
}
