using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    class RockCollision
    {
        Rock rock1;
        Rock rock2;
        
        private static ArrayList rocks = new ArrayList();

        public RockCollision()
        {
            rock1 = new Rock(.7f, .7f);
            rock2 = new Rock(.5f, .5f);
            addRock(rock1);
            addRock(rock2);
            
        }

        public static void addRock(Rock rock)
        {
            rocks.Add(rock);
        }
        public static void collisionTest(MainCharacter main, int direction)
        {
            foreach (Rock rock in rocks)
            {

                switch (direction)
                {
                    case 1:
                        if (Math.Abs(main.getX() - rock.getX()) < .19 && Math.Abs(main.getY() - rock.getY()) < .19)
                        {
                            rock.increaseX(-1 * rock.getSpeed());
                        }
                        break;
                    case 2:
                        if (Math.Abs(main.getX() - rock.getX()) < .19 && Math.Abs(main.getY() - rock.getY()) < .19)
                        {
                            rock.increaseX(1 * rock.getSpeed());
                        }
                        break;
                    case 3:
                        if (Math.Abs(main.getX() - rock.getX()) < .19 && Math.Abs(main.getY() - rock.getY()) < .19)
                        {
                            rock.increaseY(1 * rock.getSpeed());
                        }
                        break;
                    case 4:
                        if (Math.Abs(main.getX() - rock.getX()) < .19 && Math.Abs(main.getY() - rock.getY()) < .19)
                        {
                            rock.increaseY(-1 * rock.getSpeed());
                        }
                        break;
                }
            }
        }
        public static ArrayList getRocks()
        {
            return rocks;
        }

        public static void renderRocks()
        {
            
            foreach (Rock rock in rocks)
            {
                rock.renderRock();
            }
        }
    }
}
