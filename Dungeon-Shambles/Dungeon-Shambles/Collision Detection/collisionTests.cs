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
			if (current.getTileAtLocation((int)(x*5), (int)(y*5)).getIsWall())
				return true;
			else
				return false;
		}

        public static Boolean passDoor(Room current, float x, float y)
        {
            try{
            if (current.getTileAtLocation((int)(x*5+1), (int)(y*5+1)).getIsDoor())
                return true;
            else
                return false;
            }
            catch(Exception e)
            {
                return true;
            }
        }

        public static Room roomTransition(Room currentRoom, Dungeon currentDungeon, int direction)
        {
            //directions: 0 = down, 1 = left, 2 = up, 3 = right

            //room[0] down to room[4]
            //room[0] left to room[1]
            //room[0] up to room[2]
            //room[0] right to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(0)))
                switch (direction)
            {
                case 0:
                    return (Room)currentDungeon.getRooms().GetValue(4);
                case 1:
                    return (Room)currentDungeon.getRooms().GetValue(1);
                case 2:
                    return (Room)currentDungeon.getRooms().GetValue(2);
                case 3:
                    return (Room)currentDungeon.getRooms().GetValue(3);
            }

            //room[1] down to room[7]
            //room[1] left to room[5]
            //room[1] up to room[6]
            //no right
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(1)))
                switch (direction)
                {
                    case 0:
                        return (Room)currentDungeon.getRooms().GetValue(4);
                    case 1:
                        return (Room)currentDungeon.getRooms().GetValue(1);
                    case 2:
                        return (Room)currentDungeon.getRooms().GetValue(2);
                }

            //room[3] down to room[10]
            //no left
            //room[3] up to room[8]
            //room[3] right to room[9]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(3)))
                switch (direction)
                {
                    case 0:
                        return (Room)currentDungeon.getRooms().GetValue(10);
                    case 2:
                        return (Room)currentDungeon.getRooms().GetValue(8);
                    case 3:
                        return (Room)currentDungeon.getRooms().GetValue(9);
                }

            //room[4] up to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(4)))
            if (direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[1] right to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(1)))
            if (direction == 3)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[2] down to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(2)))
            if (direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[3] left to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(3)))
            if (direction == 1)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[7] up to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(7)))
            if (direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[5] right to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(5)))
            if (direction == 3)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[6] down to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(6)))
            if (direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[10] up to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(10)))
            if (direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(3);
            //room[8] down to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(8)))
            if (direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(3);
            //room[9] left to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(4)))
            if (direction == 1)
                return (Room)currentDungeon.getRooms().GetValue(3);
            return currentRoom;
            }
        }
}