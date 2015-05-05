using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Character;
using DungeonShambles.Cranting;

namespace DungeonShambles.Items
{
    class Armor
    {
        int armorValue;
        PhysicalAttribute pa;
        MagicAttribute ma;

        public Armor()
        {
            armorValue = 1;
            pa = new PhysicalAttribute();
            ma = new MagicAttribute(0);
        }

        public Armor(int modAV)
        {
            armorValue = modAV;
            pa = new PhysicalAttribute();
            ma = new MagicAttribute(0);
        }
    }
}
