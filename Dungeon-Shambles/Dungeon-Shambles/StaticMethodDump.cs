using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    static class StaticMethodDump
    {
        static Random r = new Random();

        public static Boolean statProfCheck(Double mod)
        {
            if (mod == 1) return true;
            if ((.5 + mod) * r.NextDouble() > .5) return true;
            return false;
        }

        public static Double statIncrease(Double stat)
        {
            return (stat * (1 + r.NextDouble()));
        }

        public static int randomInt(int max)
        {
            if (max == 0) return max;
            return r.Next(max);
        }
    }
}
