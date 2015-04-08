using System;

namespace DungeonShambles
{
	public class Dungeon
	{
		private Room[] rooms;
		private int numberOfRooms;

		// temporary hallways
		private Tile[,] Hallways = new Tile[30, 30];
		private int HallwaysSize = 30;

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
			// temporary hallways
			for (int i = 0; i < HallwaysSize; i++) {
				for (int j = 0; j < HallwaysSize; j++) {
					Hallways[i, j] = new Tile (Tilenames[0], 1, 1, false);
				}
			}
		}

		public void renderDungeon() {
			// temporary hallways
			for (int i = 0; i < HallwaysSize; i++) {
				for (int j = 0; j < HallwaysSize; j++) {
					Hallways [i, j].renderTile (Globals.TextureSize, i * Globals.TextureSize * 2, j * Globals.TextureSize * 2); 
				}
			}

			int generationWidth = 0;
			int generationHeight = 0;
			for (int i = 0; i < rooms.Length; i++) {
				rooms [i].renderRoom (generationWidth, generationHeight);
				generationWidth += 2;
				if (generationWidth % 3 == 0) {
					generationHeight += 2;
					generationWidth = 0;
				}
			}
		}

		public Room[] getRooms() {
			return rooms;
		}
	}
}

