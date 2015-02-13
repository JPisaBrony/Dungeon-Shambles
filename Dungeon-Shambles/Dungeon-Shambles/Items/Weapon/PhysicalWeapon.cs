using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles.Items
{
    class PhysicalWeapon : Weapon
    {
        public PhysicalWeapon()
            : base(.6, 1, 3, 1)
        {

        }

        public PhysicalWeapon(Double hit, Double damage)
            : base(hit, damage, 3, 1)
        {

        }
    }
}
