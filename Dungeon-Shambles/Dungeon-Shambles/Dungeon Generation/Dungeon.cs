using System;

namespace DungeonShambles
{
	public class Dungeon
	{
		private Room[] rooms;
		private int numberOfRooms;
        private int maxRoomSize;
        private int minRoomSize;

		string[] Tilenames = new string[] {
			"meshes/Tiles/Floor.png",
			"meshes/Tiles/WestWall.png",
			"meshes/Tiles/NorthWall.png",
			"meshes/Tiles/EastWall.png",
			"meshes/Tiles/SouthWall.png",
			"meshes/Tiles/SWCorner.png",
			"meshes/Tiles/NWCorner.png",
			"meshes/Tiles/NECorner.png",
			"meshes/Tiles/SECorner.png"
		};

        public Dungeon (int r, int minSize, int maxSize) {
			numberOfRooms = r;
            maxRoomSize = maxSize;
            minRoomSize = minSize;
		}

		public void generateDungeon() {
			rooms = new Room[numberOfRooms];
			Random rng = new Random ();
			for (int i = 0; i < numberOfRooms; i++) {
				Room newRoom = new Room (Tilenames, 1);
                newRoom.generateRoom (rng.Next(minRoomSize, maxRoomSize), rng.Next(minRoomSize, maxRoomSize));
				rooms [i] = newRoom;
			}
			// re-generate the first room with the max size of the room
            rooms [0].generateRoom (maxRoomSize, maxRoomSize);

            int currentRandomNumber = 0;
            Room smallerRoom;

            currentRandomNumber = rng.Next(1, rooms[1].getRoomHeight() - 1);
            rooms[0].setDoor(1, currentRandomNumber);
            rooms[1].setDoor(3, currentRandomNumber);
            currentRandomNumber = rng.Next(1, rooms[2].getRoomWidth() - 1);
            rooms[0].setDoor(2, currentRandomNumber);
            rooms[2].setDoor(0, currentRandomNumber);
            currentRandomNumber = rng.Next(1, rooms[3].getRoomHeight() - 1);
            rooms[0].setDoor(3, currentRandomNumber);
            rooms[3].setDoor(1, currentRandomNumber);
            currentRandomNumber = rng.Next(1, rooms[4].getRoomWidth() - 1);
            rooms[0].setDoor(0, currentRandomNumber);
            rooms[4].setDoor(2, currentRandomNumber);

            smallerRoom = getSmallerRoom(rooms[1], rooms[5], 0);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomHeight() - 1);
            rooms[1].setDoor(1, currentRandomNumber);
            rooms[5].setDoor(3, currentRandomNumber);
            smallerRoom = getSmallerRoom(rooms[1], rooms[6], 1);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomWidth() - 1);
            rooms[1].setDoor(2, currentRandomNumber);
            rooms[6].setDoor(0, currentRandomNumber);
            smallerRoom = getSmallerRoom(rooms[1], rooms[7], 1);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomWidth() - 1);
            rooms[1].setDoor(0, currentRandomNumber);
            rooms[7].setDoor(2, currentRandomNumber);

            smallerRoom = getSmallerRoom(rooms[3], rooms[8], 1);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomWidth() - 1);
            rooms[3].setDoor(2, currentRandomNumber);
            rooms[8].setDoor(0, currentRandomNumber);
            smallerRoom = getSmallerRoom(rooms[3], rooms[9], 0);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomHeight() - 1);
            rooms[3].setDoor(3, currentRandomNumber);
            rooms[9].setDoor(1, currentRandomNumber);
            smallerRoom = getSmallerRoom(rooms[3], rooms[10], 1);
            currentRandomNumber = rng.Next(1, smallerRoom.getRoomWidth() - 1);
            rooms[3].setDoor(0, currentRandomNumber);
            rooms[10].setDoor(2, currentRandomNumber);

            /*
            int roomOffset = 1;
            int timesRun = 5;
            for (int i = 0; i < 4; i++) {
                if (i == 1) {
                    timesRun = 4;
                } else if (i == 2) {
                    i = 3;
                }
                for (int j = i + 1; j < i + timesRun; j++) {
                    rooms[i].setDoor(j % 4, 3);
                    rooms[roomOffset].setDoor((j + 2) % 4, 3);
                    roomOffset++;
                }
            }*/
		}

        private Room getSmallerRoom(Room r1, Room r2, int widthOrHeight) {
            if (widthOrHeight == 0) {
                if (r1.getRoomHeight() < r2.getRoomHeight()) {
                    return r1;
                } else {
                    return r2;
                }
            } else {
                if (r1.getRoomWidth() < r2.getRoomWidth()) {
                    return r1;
                } else {
                    return r2;
                }
            }
        }

		public void renderDungeon() {
			float generationWidth = 0;
			float generationHeight = 0;
			int currentRoom = -1;
			int roomSwitching = 0;
			int roomSubtraction = 2;
			for (int i = 0; i < rooms.Length; i++) {
				switch (currentRoom % 5) {
					case -1:
						rooms [i].renderRoom (generationWidth, generationHeight);
						break;
					case 0:
						rooms [i].renderRoom (-1 * ((rooms [i].getRoomWidth () * Globals.TextureSize * 2) + generationWidth), generationHeight);
						break;
					case 1:
						if (roomSwitching == 1) {
							currentRoom++;
                            generationWidth = generationWidth * -1;
						}
						rooms [i].renderRoom (generationWidth, rooms [i-roomSubtraction].getRoomHeight () * Globals.TextureSize * 2);
						break;
                    case 2:
                        rooms [i].renderRoom ((rooms [i-(roomSubtraction+1)].getRoomWidth () * Globals.TextureSize * 2) + generationWidth, generationHeight);
						break;
					case 3:
                        rooms [i].renderRoom (generationWidth, -1 * (rooms [i].getRoomHeight () * Globals.TextureSize * 2) + generationHeight);
						break;
                    case 4:
                        i--;
                        if (roomSwitching == 0)
                            generationWidth = rooms[1].getRoomWidth() * Globals.TextureSize * 2;
                        else if (roomSwitching == 1) {
                            generationWidth = rooms[0].getRoomWidth() * Globals.TextureSize * 2;
                            currentRoom++;
                        }
						roomSubtraction = 5;
						roomSwitching++;
						break;
				}
				if (currentRoom >= 13)
					break;
				currentRoom++;
			}
		}

		public Room[] getRooms() {
			return rooms;
		}
	}
}

