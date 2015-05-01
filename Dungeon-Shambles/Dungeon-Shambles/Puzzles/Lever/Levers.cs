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
        private static Lever[] levers = new Lever[3];
        public Levers()
        {
            lever1 = new Lever(.8f, 1.8f);
            lever2 = new Lever(1f, 1.8f);
            lever3 = new Lever(1.2f, 1.8f);
            addLever(0, lever1);
            addLever(1, lever2);
            addLever(2, lever3);
            solved = false;
            door = new Door(1.6f, 1.8f);
        }

        public static void addLever(int index, Lever lever)
        {
            levers[index] = lever;
        }

        public static void flipLever(MainCharacter main)
        {
            foreach (Lever lever in levers)
            {
                if (Math.Abs((lever.getX() - main.getX())) < .05 &&
                    Math.Abs(lever.getY() - main.getY()) < .05)
                {
                    if (lever.getFlipped() == true)
                        lever.setFlippedF();
                    else if(lever.getFlipped() == false)
                        lever.setFlippedT();
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

        public static void renderLevers()
        {
            if (solved)
            {
                door.renderDoor();
            }
            foreach (Lever lever in levers)
            {
                lever.renderLever();
            }
        }
    }
}
