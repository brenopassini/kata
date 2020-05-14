using RPG_Kata.Interfaces;
using RPG_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Kata.Iterations
{
    public class Iteration4 : ICharacterActions, IFactionActions
    {
        private Character character;
        private Character enemyCharacter;

        public Iteration4(Character character, Character enemyCharacter)
        {
            this.character = character;
            this.enemyCharacter = enemyCharacter;
        }

        public void Damage(int damageValue)
        {
            if (!Allies(enemyCharacter))
            {
                //TODO regras para health não ser menor que zero
                enemyCharacter.Health -= damageValue;
            }
        }

        public void Cure(int cureValue)
        {
            if (Allies(character))
            {
                //TODO para health não ser maior que maxhealth
                enemyCharacter.Health += cureValue;
            }
        }

        public void JoinFaction(Faction faction, Character character)
        {
            if (!character.Factions.Contains(faction))
            {
                character.Factions.Add(faction);
            }
        }

        public void LeaveFaction(Faction faction, Character character)
        {
            if (character.Factions.Contains(faction))
            {
                character.Factions.Remove(faction);
            }
        }

        public bool Allies(Character enemy)
        {
            bool allies = false;
            this.character.Factions.ForEach(o => { if (enemy.Factions.Contains(o)) { allies = true; } });
            return allies;
        }
    }
}
