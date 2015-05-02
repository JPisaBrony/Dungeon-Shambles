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
        static Room currentRoom;
        public TargetTest(Room r)
        {
            target1 = new Target(4, 5);
            target2 = new Target(2, 5);
            addTarget(target1);
            addTarget(target2);
            door = new Door(.2f, .2f);
            solved = false;
            currentRoom = r;
        }

        public static void addTarget(Target target)
        {
            targets.Add(target);
        }

        public Boolean pressTest(ArrayList rocks)
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

        public void renderTargets()
        {
            if (solved == true)
            {
                door.renderDoor();
            }
            foreach (Target target in targets)
            {
                currentRoom.setAboveTileAtLocation(target.getX(), target.getY(), target.getTexture());
            }
        }
    }
}