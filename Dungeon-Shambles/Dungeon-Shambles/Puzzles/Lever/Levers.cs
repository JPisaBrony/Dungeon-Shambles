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
        private static Lever[] levers = new Lever[3];

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
    }
}
