using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    static class StaticMethodDump
    {
        public static Boolean statProfCheck(Double mod)
        {
            Random r = new Random();
            if (mod == 1) return true;
            if ((.5 + mod) * r.NextDouble() > .5) return true;
            return false;
        }
    }
}
