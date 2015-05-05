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
        static Random rand = new Random(2);
        bool solved;
        Room currentRoom;
        private ArrayList targets = new ArrayList();
        RockCollision rocks;
        public TargetTest(Room r, int x, int[] xValues, int[] yValues, RockCollision input)
        {
            currentRoom = r;     
            rocks = input;
            int count = 0;
            while (count < x)
            {
                bool valid = true;
                Target target = new Target(rand.Next(2, r.getRoomWidth() - 2), rand.Next(2, r.getRoomHeight() - 2));

                foreach (Target madeTarget in targets)
                {
                    if ((int)target.getX() == (int)madeTarget.getX() && (int)target.getY() == (int)madeTarget.getY())
                        valid = false;
                }

                for (int i = 0; i < xValues.Length; i++ )
                {
                    if(target.getX() == xValues[i] && target.getY() == yValues[i])
                    {
                        valid = false;
                    }
                }

                if (valid == true)
                {
                    targets.Add(target);
                    count++;
                }
            }           
        }

        public void addTarget(Target target)
        {
            targets.Add(target);
        }

        public Boolean pressTest()
        {
            ArrayList test = rocks.getRocks();
            int count1 = 0;
            int count2 = 0;
            float tolerance = .19f;
            foreach (Target target in targets)
            {
                count1++;
                foreach (Rock rock in test)
                {
                    if (Math.Abs(target.getX() - rock.getX()) < tolerance &&
                            (Math.Abs(target.getY() - rock.getY())) < tolerance)
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
            foreach (Target target in targets)
            {
                currentRoom.setAboveTileAtLocation(target.getX(), target.getY(), target.getTexture());
            }
        }
    }
}