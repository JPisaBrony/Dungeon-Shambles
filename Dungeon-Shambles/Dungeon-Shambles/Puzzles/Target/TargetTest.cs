using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    public class TargetTest
    {
        private static ArrayList targets = new ArrayList();

        public static void addTarget(Target target)
        {
            targets.Add(target);
        }

        public static Boolean pressTest(ArrayList rocks)
        {
            int count1 = 0;
            int count2 = 0;
            foreach (Target target in targets)
            {
                count1++;
                foreach (Rock rock in rocks)
                {
                    if((Math.Abs(rock.getX() - target.getX()) < .05 && 
                        (Math.Abs(rock.getY() - target.getY())) < .05))
                    {
                        count2++;
                    }
                }
            }
            if (count1 == count2)
                return true;
            else
                return false;
        }
    }
}
