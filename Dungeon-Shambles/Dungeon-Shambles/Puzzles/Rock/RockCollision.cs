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
        static Room currentRoom;
        private static ArrayList rocks = new ArrayList();

        public RockCollision(Room r)
        {
            rock1 = new Rock(1, 1);
            rock2 = new Rock(5, 5);
            addRock(rock1);
            addRock(rock2);
            currentRoom = r;
        }

        public static void addRock(Rock rock)
        {
            rocks.Add(rock);
        }
        public static void collisionTest(MainCharacter main, int direction)
        {
            foreach (Rock rock in rocks)
            {
                float offset = .7f;
                switch (direction)
                {
                    case 1:
                        if (Math.Abs((main.getX() - currentRoom.getcoordinateOffsetX())*5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseX(- .5f);
                        }
                        break;
                    case 2:
                        if (Math.Abs((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseX(.5f);
                        }
                        break;
                    case 3:
                        if (Math.Abs((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseY(.5f);
                        }
                        break;
                    case 4:
                        if (Math.Abs((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseY(-.5f);
                        }
                        break;
                }
            }
        }
        public static ArrayList getRocks()
        {
            return rocks;
        }

        public void renderRocks()
        {
            
            foreach (Rock rock in rocks)
            {
                currentRoom.setAboveTileAtLocation(rock.getX(), rock.getY(), rock.getTexture());
            }
        }
    }
}
