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
                    if (lever.getX() == madeLever.getX() && (lever.getY() == madeLever.getY() ||
                        lever.getY() == madeLever.getY() - 1))
                        valid = false;
                }
                if(valid == true)
                {
                    levers.Add(lever);
                    count++;
                }
            }

            foreach (Lever target in levers)
            {
                Console.WriteLine(target.getX() + ", " + target.getY());
                Console.WriteLine("BREAK");
            }

        }

        public static void addLever(int index, Lever lever)
        {
            
        }

        public void flipLever(MainCharacter main)
        {
            foreach (Lever lever in levers)
            {
                if (Math.Abs(((main.getX() - currentRoom.getcoordinateOffsetX()) * 5 - lever.getX())) < .05 &&

                    ((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - lever.getY()) > -1.2 &&
                    ((main.getY() - currentRoom.getcoordinateOffsetY()) * 5 - lever.getY()) < -.9)
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
            //setSolved();
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
