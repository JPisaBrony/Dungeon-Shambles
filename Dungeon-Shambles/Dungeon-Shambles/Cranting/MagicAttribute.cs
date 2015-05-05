using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Cranting.Encantments;

namespace DungeonShambles.Cranting
{
    class MagicAttribute
    {
        Enchantment enchantment;

        public MagicAttribute()
        {
            enchantment = randomEnchant(StaticMethodDump.randomInt(9));
        }

        public MagicAttribute(int i)
        {
            enchantment = randomEnchant(i); 
        }

        static Enchantment randomEnchant(int i)
        {
            Enchantment temp = new NoEnchant();

            switch (i)
            {
                case 0:
                    temp = new NoEnchant();
                    break;
                case 1:
                    temp = new AreaDamage();
                    break;
                case 2:
                    temp = new DamageOverTime();
                    break;
                case 3:
                    temp = new FloatOrb();
                    break;
                case 4:
                    temp = new LifeSteal();
                    break;
                case 5:
                    temp = new MagicShield();
                    break;
                case 6:
                    temp = new ReflectMagicDamage();
                    break;
                case 7:
                    temp = new NoEnchant();
                    break;
                case 8:
                    temp = new NoEnchant();
                    break;
                case 9:
                    temp = new NoEnchant();
                    break;

            }
            return temp;
        }
    }
}
