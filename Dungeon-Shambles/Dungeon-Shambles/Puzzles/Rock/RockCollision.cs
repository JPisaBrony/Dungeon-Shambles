using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DungeonShambles.Entities;
namespace DungeonShambles
{
    public class RockCollision
    {
        static Random rand = new Random();
        Room currentRoom;
        private ArrayList rocks = new ArrayList();
        int[] xValues;
        int[] yValues;
        public RockCollision(Room r, int x)
        {
            int count = 0;
            xValues = new int[x];
            yValues = new int[x];
            
            while (count < x)
            {
                bool valid = true;
                Rock rock = new Rock(rand.Next(2, r.getRoomWidth() - 2), rand.Next(2, r.getRoomHeight() - 2));

                foreach (Rock madeRock in rocks)
                {
                    if (rock.getX() == madeRock.getX() && rock.getY() == madeRock.getY())
                        valid = false;
                }
                if(valid == true)
                {
                    rocks.Add(rock);
                    xValues[count] = (int)rock.getX();
                    yValues[count] = (int)rock.getY();

                    count++;
                }
            }
            currentRoom = r;
            
        }

        public void addRock(Rock rock)
        {
            rocks.Add(rock);
        }
        public void collisionTest(GameEntities main, int direction)
        {
            foreach (Rock rock in rocks)
            {
                float offset = .7f;
                switch (direction)
                {
                    case 1:
                        if (Math.Abs((main.getX() - currentRoom.getOffsetX())*5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseX(- .2f);
                        }
                        break;
                    case 2:
                        if (Math.Abs((main.getX() - currentRoom.getOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseX(.2f);
                        }
                        break;
                    case 3:
                        if (Math.Abs((main.getX() - currentRoom.getOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseY(.2f);
                        }
                        break;
                    case 4:
                        if (Math.Abs((main.getX() - currentRoom.getOffsetX()) * 5 - rock.getX()) < offset &&
                            Math.Abs((main.getY() - currentRoom.getOffsetY()) * 5 - rock.getY()) < offset)
                        {
                            rock.increaseY(-.2f);
                        }
                        break;
                }
            }
        }
        public ArrayList getRocks()
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

        public int[] getXValues()
        {
            return xValues;
        }

        public int[] getYValues()
        {
            return yValues;
        }
        
    }
}
