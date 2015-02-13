using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Cranting;

namespace DungeonShambles.Items
{
    class MagicWeapon : Weapon
    {
        public MagicWeapon()
            : base(1, 1, 1, 3)
        {

        }

        public MagicWeapon(Double damage)
            : base(1, damage, 1, 3)
        {
            
        }
    }
}
