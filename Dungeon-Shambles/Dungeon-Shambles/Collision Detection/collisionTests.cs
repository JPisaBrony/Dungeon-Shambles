using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonShambles.Entities;

namespace DungeonShambles
{
    public static class collisionTests
    { 

        public static Boolean collision(GameEntities ob1, GameEntities ob2)
        {
            if ((Math.Abs(ob1.getX() - ob2.getX()) < 0.1f) && 
                (Math.Abs(ob1.getY() - ob2.getY()) < 0.1f))
            {
                return true;
            }
            else
                return false;
        }
		public static Boolean wallCollision (Room current, float x, float y)
		{
			//Check if tile character is moving into is a wall
			if (current.getTileAtLocation((int)(x*5+1), (int)(y*5+1)).getIsWall())
				return true;
			else
				return false;
		}
        /*
        public static Room roomtransition(Room currentRoom, Dungeon currentDungeon)
        {
            //if player is on the door square then it will return the next room
            Room temp;
            if (currentRoom.getTileAtLocation((int)(x*5), (int)(y*5)).getDoor())
                return currentDungeon.getDoorConnection();
            else
                return currentRoom;
        }
        */
    }
}
