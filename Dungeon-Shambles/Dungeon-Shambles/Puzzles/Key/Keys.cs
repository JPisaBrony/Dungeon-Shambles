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
        static Key k;
        static Door door;
        static bool solved;
        private static ArrayList keys = new ArrayList();
        public Keys()
        {
            solved = false;
            door = new Door(1.8f, 1.2f);
            k = new Key(0.4f, 0.4f);
            keys.Add(k);
        }

        public static void addKey(Key key)
        {
            keys.Add(key);
        }

        public static void pickUpKey(MainCharacter main)
        {
            foreach (Key key in keys)

                if (Math.Abs((key.getX() - main.getX())) < .05 &&
                    Math.Abs(key.getY() - main.getY()) < .05)
                {
                    key.pickUp();
                    checkSolved();
                }
        }
        
        public static Key getKey()
        {
            return k;
        }

        public static void renderKeys()
        {
            if (solved == false)
                k.renderKey();
            if(solved == true)
                door.renderDoor();
        }

        public static bool checkSolved()
        {
            if (k.getPickedUp() == true)
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
