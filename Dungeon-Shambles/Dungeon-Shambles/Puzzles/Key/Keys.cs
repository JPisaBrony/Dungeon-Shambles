using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DungeonShambles
{
    
    public class Keys
    {
        Key key;
        Door door;
        bool solved;
        Room currentRoom;
        private static ArrayList keys = new ArrayList();
        public Keys(Room r)
        {
            solved = false;
            door = new Door(1.8f, 1.2f);
            key = new Key(1, 1);
            keys.Add(key);
            currentRoom = r;
        }

        public static void addKey(Key key)
        {
            keys.Add(key);
        }

        public void pickUpKey(MainCharacter main)
        {
            foreach (Key key in keys)

                if (Math.Abs(((main.getX() -currentRoom.getcoordinateOffsetX())*5 - key.getX())) < .05 &&
                    Math.Abs(((main.getY() -currentRoom.getcoordinateOffsetY())*5 - key.getY())) < .05)
                {
                    key.pickUp();
                    checkSolved();
                }
        }
        
        public Key getKey()
        {
            return key;
        }

        public void renderKeys()
        {
            if (solved == false)
                currentRoom.setAboveTileAtLocation(key.getX(), key.getY(), key.getTexture());
            if(solved == true)
                door.renderDoor();
        }

        public bool checkSolved()
        {
            if (key.getPickedUp() == true)
            {
                solved = true;
                return solved;
            }
            else
            {
                return solved;
            }
        }
    }
}
