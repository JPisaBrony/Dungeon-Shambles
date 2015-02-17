using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.Character
{
    class CharacterStatus
    {
        Double health;
        Double mana;
        Double meleeModifier;
        Double magicModifier;

        public CharacterStatus()
        {
            health = 100;
            mana = 100;
            meleeModifier = 0;
            magicModifier = 0;
        }

        public CharacterStatus(Double h, Double m, Double cMod, Double aMod)
        {
            health = h;
            mana = m;
            meleeModifier = cMod;
            magicModifier = aMod;
        }
        

    }    
}
