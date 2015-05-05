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

        public static void setCurrentRoom(GameEntities player, int direction, Dungeon dungeon) {
            Room r = player.getCurrentRoom();
            switch (direction) {
                case 0: // down
                    if (r.getOffsetY() > player.getY())
                        player.setCurrentRoom(roomTransition(player.getCurrentRoom(), dungeon, direction));
                    break;
                case 1: // left
                    if (r.getOffsetX() > player.getX())
                        player.setCurrentRoom(roomTransition(player.getCurrentRoom(), dungeon, direction));
                    break;
                case 2: // up
                    if ((0.2f*r.getRoomHeight() + r.getOffsetY()) > player.getY())
                        player.setCurrentRoom(roomTransition(player.getCurrentRoom(), dungeon, direction));
                    break;
                case 3: // right
                    if (0.2f*r.getRoomWidth() + r.getOffsetX() > player.getX())
                        player.setCurrentRoom(roomTransition(player.getCurrentRoom(), dungeon, direction));
                    break;
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
                        return (Room)currentDungeon.getRooms().GetValue(7);
                    case 1:
                        return (Room)currentDungeon.getRooms().GetValue(5);
                    case 2:
                        return (Room)currentDungeon.getRooms().GetValue(6);
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
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(4)) && direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[1] right to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(1)) && direction == 3)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[2] down to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(2)) && direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[3] left to room[0]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(3)) && direction == 1)
                return (Room)currentDungeon.getRooms().GetValue(0);
            //room[7] up to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(7)) && direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[5] right to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(5)) && direction == 3)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[6] down to room[1]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(6)) && direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(1);
            //room[10] up to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(10)) && direction == 2)
                return (Room)currentDungeon.getRooms().GetValue(3);
            //room[8] down to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(8)) && direction == 0)
                return (Room)currentDungeon.getRooms().GetValue(3);
            //room[9] left to room[3]
            if (currentRoom.Equals(currentDungeon.getRooms().GetValue(9)) && direction == 1)
                return (Room)currentDungeon.getRooms().GetValue(3);
            return currentRoom;
            }
        }
}