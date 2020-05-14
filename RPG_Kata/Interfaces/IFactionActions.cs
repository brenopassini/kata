using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Interfaces
{
    interface IFactionActions
    {
        void JoinFaction(Faction faction, Character character);

        void LeaveFaction(Faction faction, Character character);
    }
}
