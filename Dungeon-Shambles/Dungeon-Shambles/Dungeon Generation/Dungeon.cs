using System;

namespace DungeonShambles
{
	public class Dungeon
	{
		private Room[] rooms;
		private int numberOfRooms;

		string[] Tilenames = new string[] {
			"meshes/D1Tiles/D1Floor.png",
			"meshes/D1Tiles/D1WestWall.png",
			"meshes/D1Tiles/D1NorthWall.png",
			"meshes/D1Tiles/D1EastWall.png",
			"meshes/D1Tiles/D1SouthWall.png",
			"meshes/D1Tiles/SWCorner.png",
			"meshes/D1Tiles/NWCorner.png",
			"meshes/D1Tiles/NECorner.png",
			"meshes/D1Tiles/SECorner.png"
		};

		public Dungeon (int r) {
			numberOfRooms = r;
		}

		public void generateDungeon() {
			rooms = new Room[numberOfRooms];
			Random rng = new Random ();
			for (int i = 0; i < numberOfRooms; i++) {
				Room newRoom = new Room (Tilenames, 1);
				newRoom.generateRoom (rng.Next(4, 10), rng.Next(4, 10), 2);
				rooms [i] = newRoom;
			}
			// re-generate the first room with the max size of the room
			rooms [0].generateRoom (10, 10, 4);
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

