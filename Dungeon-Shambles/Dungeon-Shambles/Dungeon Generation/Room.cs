using System;

namespace DungeonShambles
{
	public class Room
	{
		private Tile[,] tiles;
		private int roomWidth, roomHeight;
		private string[] tileNames;
		private int tileSize;
		private int numberOfDoors;

		public Room (string[] tNames, int tSize) {
			tileSize = tSize;
			tileNames = tNames;
		}

		public void generateRoom(int w, int h, int doors) {
			tiles = new Tile[w, h];
			roomWidth = w;
			roomHeight = h;
			numberOfDoors = doors;
			int doorsPlaced = 0;
			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					if (i == 0 && j == 0) {
						tiles [i, j] = new Tile (tileNames [5], tileSize, tileSize, true);
					} else if (i == 0 && j == h - 1) {
						tiles [i, j] = new Tile (tileNames [6], tileSize, tileSize, true);
					} else if (i == w - 1 && j == h - 1) {
						tiles [i, j] = new Tile (tileNames [7], tileSize, tileSize, true);
					} else if (i == w - 1 && j == 0) {
						tiles [i, j] = new Tile (tileNames [8], tileSize, tileSize, true);
					} else if (i == 0) {
						tiles [i, j] = new Tile (tileNames [1], tileSize, tileSize, true);
						placeDoor (ref doorsPlaced, i, j);
					} else if (j == h - 1) {
						tiles [i, j] = new Tile (tileNames [2], tileSize, tileSize, true);
						placeDoor (ref doorsPlaced, i, j);
					} else if (i == w - 1) {
						tiles [i, j] = new Tile (tileNames [3], tileSize, tileSize, true);
						placeDoor (ref doorsPlaced, i, j);
					} else if (j == 0) {
						tiles [i, j] = new Tile (tileNames [4], tileSize, tileSize, true);
						placeDoor (ref doorsPlaced, i, j);
					} else {
						tiles [i, j] = new Tile (tileNames [0], tileSize, tileSize, false);
					}
				}
			}
		}

		private void placeDoor(ref int doorsPlaced, int i, int j) {
			Random rng = new Random ();
			if(rng.Next(0, 5) == 0) {
				if (doorsPlaced < numberOfDoors) {
					tiles [i, j] = new Tile (tileNames [0], tileSize, tileSize, false);
					doorsPlaced++;
				}
			}
		}

		public void renderRoom(int offsetX, int offsetY) {
			for (int i = 0; i < roomWidth; i++) {
				for (int j = 0; j < roomHeight; j++) {
					tiles [i,j].renderTile (Globals.TextureSize, i * Globals.TextureSize * 2 + offsetX, j * Globals.TextureSize * 2 + offsetY);
				}
			}
		}

		public Tile getTileAtLocation(int x, int y) {
			return tiles [x, y];
		}

		public int getRoomWidth() {
			return roomWidth;
		}

		public int getRoomHeight() {
			return roomHeight;
		}
	}
}

