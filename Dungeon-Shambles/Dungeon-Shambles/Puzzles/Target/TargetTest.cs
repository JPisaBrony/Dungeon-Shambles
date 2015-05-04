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
        Target target1;
        Target target2;
        static Door door;
        static bool solved;
        private static ArrayList targets = new ArrayList();

        public TargetTest()
        {
            target1 = new Target(.1f, .1f);
            target2 = new Target(.5f, .9f);
            addTarget(target1);
            addTarget(target2);
            door = new Door(.2f, .2f);
            solved = false;
        }

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
            {
                solved = true;
                return true;

            }
            else
                return false;
        }

        public static void renderTargets()
        {
            if (solved == true)
            {
                door.renderDoor();
            }
            foreach (Target target in targets)
            {
                target.renderTarget();
            }
        }
    }
}