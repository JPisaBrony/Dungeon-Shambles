﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    
    public class Keys
    {
        static Random rand = new Random();
        Room currentRoom;
        private ArrayList keys = new ArrayList();
        public Keys(Room r, int x)
        {
            int count = 0;
            currentRoom = r;

            while (count < x)
            {
                bool valid = true;
                Key key = new Key(rand.Next(1, r.getRoomWidth() -1), rand.Next(1, r.getRoomHeight() -1));

                foreach (Key madeKey in keys)
                {
                    if (key.getX() == madeKey.getX() && key.getY() == madeKey.getY())
                    {
                        valid = false;
                    }
                }
                if (valid == true)
                {
                    keys.Add(key);
                    count++;
                }
            }
        }


        public void pickUpKey(MainCharacter main)
        {
            foreach (Key key in keys)

                if (Math.Abs(((main.getX() -currentRoom.getcoordinateOffsetX())*5 - key.getX())) < .05 &&
                    Math.Abs(((main.getY() -currentRoom.getcoordinateOffsetY())*5 - key.getY())) < .05)
                {
                    key.pickUp();
                }
        }
        

        public void renderKeys()
        {
            foreach (Key key in keys)
            {
                if (key.getPickedUp() == false)
                {
                    currentRoom.setAboveTileAtLocation(key.getX(), key.getY(), key.getTexture());
                }
            }
        }


        public bool checkKeys()
        {
            bool test = true;
            foreach (Key key in keys)
            {
                if (key.getPickedUp() == false)
                    test = false;
            }
            return test;
        }
    }
}