using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    public class Levers
    {
        Lever lever1;
        Lever lever2;
        Lever lever3;
        static bool solved;
        static Door door;
        static Room currentRoom;
        private static Lever[] levers = new Lever[3];
        public Levers(Room r)
        {
            lever1 = new Lever(0, 0);
            lever2 = new Lever(3, 1);
            lever3 = new Lever(0, 3);
            addLever(0, lever1);
            addLever(1, lever2);
            addLever(2, lever3);
            solved = false;
            door = new Door(1.6f, 1.8f);
            currentRoom = r;
        }

        public static void addLever(int index, Lever lever)
        {
            levers[index] = lever;
        }

        public void flipLever(MainCharacter main)
        {
            foreach (Lever lever in levers)
            {
                if (Math.Abs(((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - lever.getX())) < .05 &&
                    Math.Abs(((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - lever.getY())) < .05)
                {
                    if (lever.getFlipped() == true)
                    {
                        lever.setFlippedF();
                        
                    }
                    else if (lever.getFlipped() == false)
                    {
                        lever.setFlippedT();

                    }
                }
            }
            setSolved();
        }

        public static bool checkSolved()
        {
            bool solved = true;
            if (levers[2].getFlipped() == false)
                foreach (Lever lever in levers)
                    lever.setFlippedF();
            else if(levers[0].getFlipped() == false)
            {
                levers[1].setFlippedF();
            }
            foreach (Lever lever in levers)
                if (lever.getFlipped() == false)
                    solved = false;
                

            return solved;
        }

        public static void setSolved()
        {
            if(checkSolved())
            {
                solved = true;
            }
        }

        public void renderLevers()
        {
            if (solved)
            {
                door.renderDoor();
            }
            foreach (Lever lever in levers)
            {
                currentRoom.setAboveTileAtLocation(lever.getX(), lever.getY(), lever.getCurrentTexture());
            }
        }
    }
}
