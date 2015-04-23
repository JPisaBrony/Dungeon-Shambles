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
        private static ArrayList rocks = new ArrayList();

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
    }
}
