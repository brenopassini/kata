using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata
{
    public class Thing : ICreate<Thing>
    {
        private string _idThing { get; set; }
        public string IdThing
        {
            get
            {
                return _idThing;
            }
            set
            {
                _idThing = value;
            }
        }

        private string _name { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private bool _hasHealth { get; set; }
        public bool HasHealth
        {
            get
            {
                return _hasHealth;
            }
            set
            {
                _hasHealth = value;
            }
        }

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

        private TypeThing _typeThing { get; set; }
        public TypeThing TypeThing
        {
            get
            {
                return _typeThing;
            }
            set
            {
                _typeThing = value;
            }
        }

        public Thing Create(object paramsStart)
        {
            ThingModel thingModel = (ThingModel)paramsStart;
            this.IdThing = thingModel.IdThing;
            this.Name = thingModel.Name;
            this.HasHealth = thingModel.HasHealth;
            this.Health = thingModel.Health;
            this.TypeThing = thingModel.TypeThing;

            return this;
        }
    }
}
