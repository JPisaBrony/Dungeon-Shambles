using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class collisionTests
    { 
        /* Everytime a move key is pressed, character portrait moves 0.1 units.  Tiles and portrait
         * are 0.2 wide and 0.2 tall.  Therefore, you only cross into another tile when you are at
         * an odd decimal (0.1, 0.3, etc).  Easiest way to solve this issue is multiply by 10 and
         * convert to integers, then check if %2 remainder is 1.  Then account for offset of character
         * location since charX and charY are located in lower left-hand corner of image.'
         * 
         * Requires 4 methods as there is no way to detect whether you are moving into the square
         * from the left or right, top or bottom.
         */

        //Detects collision if moving character left
        //parameters are room and x, y coordinates of character
        public static Boolean wallCollisionLeft(Room current, float charCordX, float charCordY)
        {
            //Multiply by 10 to get into integers for referencing squares of room
            int testCalcX = (int) (charCordX * 10);
            int testCalcY = (int) (charCordY * 10);

            //Only check for collision if 1/2 way over a tile while moving right
            if (testCalcX % 2 == 0)
                return false;
            else
            {
                //Divide by 2 to get exact integer coordinates of tile you are attempting to move into
                int xTest = testCalcX / 2;
                int yTest = testCalcY / 2;

                //Check if tile character is moving into is a wall
                if (current.getTileAtLocation(xTest, yTest).getIsWall())
                    return true;
                else
                    return false;
            }
        }

        //Detects collision if moving right
        public static Boolean wallCollisionRight(Room current, float charCordX, float charCordY)
        {
            int testCalcX = (int)(charCordX * 10);
            int testCalcY = (int)(charCordY * 10);

            if (testCalcX % 2 == 0)
                return false;
            else
            {
                int xTest = testCalcX / 2 + 1;
                int yTest = testCalcY / 2;

                if (current.getTileAtLocation(xTest, yTest).getIsWall())
                    return true;
                else
                    return false;
            }
        }

        //Detects collision moving up
        public static Boolean wallCollisionUp(Room current, float charCordX, float charCordY)
        {
            int testCalcX = (int)(charCordX * 10);
            int testCalcY = (int)(charCordY * 10);

            if (testCalcY % 2 == 0)
                return false;
            else
            {
                int xTest = testCalcX / 2;
                int yTest = testCalcY / 2 + 1;

                if (current.getTileAtLocation(xTest, yTest).getIsWall())
                    return true;
                else
                    return false;
            }
        }

        //Detects collision moving down
        public static Boolean wallCollisionDown(Room current, float charCordX, float charCordY)
        {
            int testCalcX = (int)(charCordX * 10);
            int testCalcY = (int)(charCordY * 10);

            if (testCalcY % 2 == 0)
                return false;
            else
            {
                int xTest = testCalcX / 2;
                int yTest = testCalcY / 2;

                if (current.getTileAtLocation(xTest, yTest).getIsWall())
                    return true;
                else
                    return false;
            }
        }
    }
}
