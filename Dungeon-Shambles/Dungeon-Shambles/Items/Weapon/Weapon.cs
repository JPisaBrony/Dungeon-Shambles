using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Cranting;

namespace DungeonShambles.Items
{
    class Weapon
    {
        Double hit;
        Double damage;
        PhysicalAttribute[] pa;
        MagicAttribute[] ma;

        public Weapon(Double h, Double d, int p, int m)
        {
            hit = h;
            damage = d;
            pa = new PhysicalAttribute[p];
            ma = new MagicAttribute[m];
            if (p == 1) pa[0] = new PhysicalAttribute(6);
            else
            {
                for (int i = 0; i < pa.Length; i++)
                {
                    pa[i] = new PhysicalAttribute();
                }
            }
        }
    }
}
