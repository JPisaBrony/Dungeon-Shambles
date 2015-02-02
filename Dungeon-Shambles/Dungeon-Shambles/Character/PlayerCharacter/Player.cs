using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.Character
{
    class Player : CharacterStatus
    {
        Double crafting;
        Double weaponCraftProf;
        Double armorCraftProf;

        Double enchanting;

        public Player() : base()
        {            
            crafting = 0;
            weaponCraftProf = 0;
            armorCraftProf = 0;
            enchanting = 0;
        }


    }
}
