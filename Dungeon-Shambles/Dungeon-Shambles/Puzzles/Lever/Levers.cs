using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using DungeonShambles.Entities;
namespace DungeonShambles
{
    public class Levers
    {

        static Random rand = new Random();
        Room currentRoom;
        private ArrayList levers = new ArrayList();
        public Levers(Room r, int x)
        {
            int count = 0;
            currentRoom = r;

            while(count < x)
            {
                bool valid = true;
                Lever lever = new Lever(rand.Next(2, r.getRoomWidth() - 2), rand.Next(2, r.getRoomHeight() - 2));

                foreach (Lever madeLever in levers)
                {
                    if ((int)lever.getX() == (int)madeLever.getX() && ((int)lever.getY() == (int)madeLever.getY() ||
                       ((int)lever.getY() == (int)madeLever.getY() - 1)) || ((int)lever.getY() == (int)madeLever.getY() + 1))
                        valid = false;
                }
                if(valid == true)
                {
                    levers.Add(lever);
                    count++;
                }
            }
        }



        public void flipLever(GameEntities main)
        {
            foreach (Lever lever in levers)
            {
                if (Math.Abs(((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - lever.getX())) < .5 &&

                    ((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - lever.getY()) > -1.5 &&
                    ((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - lever.getY()) < -.5)
                {
                    if (lever.getFlipped() == false)
                    {
                        lever.setFlippedT();
                        checkLeverFlips();
                    }
                    if(lever.getFlipped() == true)
                    {
                        checkLeverFlips();
                        lever.setFlippedT();
                    }
                }
            }
        }

        public bool checkLeverFlips()
        {
            bool solved = false;
            if (levers.Count == 1)
            {
                Lever temp1 = (Lever)levers[0];
                if (temp1.getFlipped() == true)
                    solved = true;
            }

            if(levers.Count == 2)
            {
                Lever temp1 = (Lever)levers[0];
                Lever temp2 = (Lever)levers[1];
                if (temp1.getFlipped() == false)
                {
                    foreach (Lever lever in levers)
                    {
                        lever.setFlippedF();
                    }
                }
                else if (temp1.getFlipped() == true && temp2.getFlipped() == true)
                    solved = true;
            }

            if(levers.Count == 3)
            {
                Lever temp1 = (Lever)levers[0];
                Lever temp2 = (Lever)levers[1];
                Lever temp3 = (Lever)levers[2];

                if (temp1.getFlipped() == false)
                {
                    foreach (Lever lever in levers)
                    {
                        lever.setFlippedF();
                    }
                }
                if (temp1.getFlipped() == true && temp2.getFlipped() == false)
                {
                    if (temp3.getFlipped() == true)
                    {
                        foreach (Lever lever in levers)
                        {
                            lever.setFlippedF();
                        }
                    }
                }
                if (temp1.getFlipped() == true && temp2.getFlipped() == true && temp3.getFlipped())
                    solved = true;
            }
            return solved;
        }

        public void renderLevers()
        {
            foreach (Lever lever in levers)
            {
                currentRoom.setAboveTileAtLocation(lever.getX(), lever.getY(), lever.getCurrentTexture());
            }
        }
    }
}
