using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Models
{
    public class ThingModel
    {
        public string IdThing { get; set; }

        public string Name { get; set; }

        public bool HasHealth { get; set; }

        public int Health { get; set; }

        public TypeThing TypeThing { get; set; }
    }
}
