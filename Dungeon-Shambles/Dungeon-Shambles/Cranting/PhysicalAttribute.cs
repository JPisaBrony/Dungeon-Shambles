using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Cranting.CraftingStatMods;

namespace DungeonShambles.Cranting
{
    class PhysicalAttribute
    {
        StatMod mod;

        public PhysicalAttribute()
        {
            mod = randomMod(StaticMethodDump.randomInt(5));
        }

        public PhysicalAttribute(int i)
        {
            mod = randomMod(i);
        }

        static StatMod randomMod(int i)
        {
            StatMod temp = new NoStatMod();

            switch (i)
            {
                case 0:
                    temp = new NoStatMod();
                    break;
                case 1:
                    temp = new IncreaseDamage();
                    break;
                case 2:
                    temp = new IncreaseDefence();
                    break;
                case 3:
                    temp = new IncreaseHitChance();
                    break;
                case 4:
                    temp = new NoStatMod();
                    break;
                case 5:
                    temp = new ReflectPhysicalDamage();
                    break;
                case 6:
                    temp = new RangeHit();
                    break;
            }
            return temp;
        }
    }
}
